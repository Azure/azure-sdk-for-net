// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Communication.CallingServer
{
    internal class CallConnectionLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallConnectionLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RemoveAPSTNUserFromAnOngoingCallTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target and A PSTN target.
             * 3. get updated call properties and check for the connected state and check for 3 participants in total.
             * 4. remove the PSTN call leg by calling RemoveParticipants.
             * 5. verify existing call is still ongoing and has 2 participants now.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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

                CreateCallResult createCallResult = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                Assert.AreEqual(2, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(3, participants.Value.Count);

                var removeParticipantsResult = await createCallResult.CallConnection.RemoveParticipantsAsync(new CommunicationIdentifier[] { pstnTarget }).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(2, participants.Value.Count);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            finally {
                await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task RemoveAPSTNUserAndAcsUserFromAnOngoingCallTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call from source to 2 ACS targets and A PSTN target.
             * 3. get updated call properties and check for the connected state and check for 4 participants in total.
             * 4. remove the PSTN call leg and 1 Acs call leg by calling RemoveParticipants.
             * 5. verify existing call is still ongoing and has 2 participants now.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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

                CreateCallResult createCallResult = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                Assert.AreEqual(3, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(4, participants.Value.Count);

                var removeParticipantsResult = await createCallResult.CallConnection.RemoveParticipantsAsync(new CommunicationIdentifier[] { acsTarget2, pstnTarget }).ConfigureAwait(false);
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
                await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task StartAGroupCallAndHangUpTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a group call.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up (leave) the call.
             * 5. verify that call connection cannot be found.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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

                CreateCallResult createCallResult = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;
                Assert.AreEqual(2, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(3, participants.Value.Count);

                await client.GetCallConnection(callConnectionId).HangUpAsync(false).ConfigureAwait(false);
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task StartAGroupCallAndHangUpForEveryoneTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a group call.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call for everyone.
             * 5. verify that call connection cannot be found.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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

                CreateCallResult createCallResult = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;
                Assert.AreEqual(2, properties.Value.Targets.Count);
                callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var participants = await createCallResult.CallConnection.GetParticipantsAsync().ConfigureAwait(false);
                Assert.AreEqual(3, participants.Value.Count);

                await client.GetCallConnection(callConnectionId).HangUpAsync(true).ConfigureAwait(false);
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task TransferACallFromOneUserToAnotherUserTest()
        {
            /* Test case:
             * 1. create a CallAutomationClient.
             * 2. create a call to a single target.
             * 3. get updated call properties and check for the connected state.
             * 4. transfer the call to another target.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

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

                CreateCallResult createCallResult = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await createCallResult.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                var callConnectionId = properties.Value.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);

                var transferResult = await client.GetCallConnection(callConnectionId).TransferCallToParticipantAsync(new CommunicationUserIdentifier(TestEnvironment.TargetUserId2)).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
