// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallConnections
{
    internal class CallConnectionLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallConnectionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task RemoveAPSTNUserFromAnOngoingCallTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target and A PSTN target.
             * 3. get updated call properties and check for the connected state and check for 3 participants in total.
             * 4. remove the PSTN call leg by calling RemoveParticipants.
             * 5. verify existing call is still ongoing and has 2 participants now.
            */

            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string callConnectionId = "";

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user)
                {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };
                var acsTarget = new CommunicationUserIdentifier(TestEnvironment.TargetUserId);
                var pstnTarget = new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber);
                var targets = new CommunicationIdentifier[] { acsTarget, pstnTarget };

                var createCallOptions = new CreateCallOptions(source, targets, new Uri(TestEnvironment.AppCallbackUrl)) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("569bb5c2-15ab-4b14-81e7-c980b115ac9c"), new DateTimeOffset(2022, 10, 06, 0, 44, 34, new TimeSpan(0, 0, 0)))
                };
                CreateCallResult createCallResult = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                Assert.AreEqual(2, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(3, participants.Value.Count);

                var removeParticipantsOptions = new RemoveParticipantsOptions(new CommunicationIdentifier[] { pstnTarget }) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("4b199743-162b-4885-9144-b0a429fcd935"), new DateTimeOffset(2022, 10, 06, 0, 44, 45, new TimeSpan(0, 0, 0)))
                };
                var removeParticipantsResult = await createCallResult.CallConnection.RemoveParticipantsAsync(removeParticipantsOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(2, participants.Value.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally {
                var hangUpOptions = new HangUpOptions(true)
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("a739af79-dd77-41d1-81d0-8ec1f1269ab1"), new DateTimeOffset(2022, 10, 06, 0, 44, 55, new TimeSpan(0, 0, 0)))
                };
                await client.GetCallConnection(callConnectionId).HangUpAsync(hangUpOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
        }

        [Test]
        public async Task RemoveAPSTNUserAndAcsUserFromAnOngoingCallTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call from source to 2 ACS targets and A PSTN target.
             * 3. get updated call properties and check for the connected state and check for 4 participants in total.
             * 4. remove the PSTN call leg and 1 Acs call leg by calling RemoveParticipants.
             * 5. verify existing call is still ongoing and has 2 participants now.
            */

            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            string callConnectionId = "";

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user)
                {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };
                var acsTarget1 = new CommunicationUserIdentifier(TestEnvironment.TargetUserId);
                var acsTarget2 = new CommunicationUserIdentifier(TestEnvironment.TargetUserId2);
                var pstnTarget = new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber);
                var targets = new CommunicationIdentifier[] { acsTarget1, acsTarget2, pstnTarget };

                var createCallOptions = new CreateCallOptions(source, targets, new Uri(TestEnvironment.AppCallbackUrl))
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("7e4058e8-00e4-4fc7-9135-95c2ca839852"), new DateTimeOffset(2022, 10, 06, 0, 42, 52, new TimeSpan(0, 0, 0)))
                };
                CreateCallResult createCallResult = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                Assert.AreEqual(3, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(4, participants.Value.Count);

                var removeParticipantsOptions = new RemoveParticipantsOptions(new CommunicationIdentifier[] { acsTarget2, pstnTarget }) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("25f0d212-b699-4d06-9333-655b32cd8a61"), new DateTimeOffset(2022, 10, 06, 0, 43, 12, new TimeSpan(0, 0, 0)))
                };
                var removeParticipantsResult = await createCallResult.CallConnection.RemoveParticipantsAsync(removeParticipantsOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(2, participants.Value.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally
            {
                var hangUpOptions = new HangUpOptions(true)
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("7b64737f-74a9-4daf-97fc-0b7b7cc736e3"), new DateTimeOffset(2022, 10, 06, 0, 43, 22, new TimeSpan(0, 0, 0)))
                };
                await client.GetCallConnection(callConnectionId).HangUpAsync(hangUpOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
        }

        [Test]
        public async Task StartAGroupCallAndHangUpForEveryoneTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a group call.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call for everyone.
             * 5. verify that call connection cannot be found.
            */

            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            var callConnectionId = "";
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user)
                {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };
                var acsTarget = new CommunicationUserIdentifier(TestEnvironment.TargetUserId);
                var pstnTarget = new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber);
                var targets = new CommunicationIdentifier[] { acsTarget, pstnTarget };

                var createCallOptions = new CreateCallOptions(source, targets, new Uri(TestEnvironment.AppCallbackUrl)) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("3a6d6863-6e6a-4ba5-a88e-52dbf943c2c6"), new DateTimeOffset(2022, 10, 06, 0, 45, 52, new TimeSpan(0, 0, 0)))
                };
                CreateCallResult createCallResult = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;
                Assert.AreEqual(2, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(3, participants.Value.Count);

                var hangUpOptions = new HangUpOptions(true)
                {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("f40635f8-7d91-49d3-a024-9989a315fb98"), new DateTimeOffset(2022, 10, 06, 0, 46, 03, new TimeSpan(0, 0, 0)))
                };
                await client.GetCallConnection(callConnectionId).HangUpAsync(hangUpOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

                Assert.Fail("Call Connection should not be found after calling HangUp");
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && wasConnected)
                {
                    // call hung up successfully
                    Assert.Pass();
                }
                Assert.Fail($"Request failed error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task TransferACallFromOneUserToAnotherUserTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call to a single target.
             * 3. get updated call properties and check for the connected state.
             * 4. transfer the call to another target.
            */

            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user)
                {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };
                var acsTarget = new CommunicationUserIdentifier(TestEnvironment.TargetUserId);
                var targets = new CommunicationIdentifier[] { acsTarget };

                var createCallOptions = new CreateCallOptions(source, targets, new Uri(TestEnvironment.AppCallbackUrl)) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("5a555e82-f4ce-4467-9ca9-e2dae4c69e61"), new DateTimeOffset(2022, 10, 06, 0, 49, 16, new TimeSpan(0, 0, 0)))
                };
                CreateCallResult createCallResult = await client.CreateCallAsync(createCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                var callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var transferCallOptions = new TransferToParticipantOptions(new CommunicationUserIdentifier(TestEnvironment.TargetUserId2)) {
                    RepeatabilityHeaders = new RepeatabilityHeaders(new Guid("14b01890-e1d9-49ad-9382-3e852735a994"), new DateTimeOffset(2022, 10, 06, 0, 49, 27, new TimeSpan(0, 0, 0)))
                };
                var transferResult = await client.GetCallConnection(callConnectionId).TransferCallToParticipantAsync(transferCallOptions).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
