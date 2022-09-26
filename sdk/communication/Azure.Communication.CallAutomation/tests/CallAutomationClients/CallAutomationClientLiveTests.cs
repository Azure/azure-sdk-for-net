// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Azure.Communication.CallAutomation.Tests.Infrastructure;

namespace Azure.Communication.CallAutomation.Tests.CallAutomationClients
{
    internal class CallAutomationClientLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallAutomationClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateCallToACSGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call.
             * 5. once call is hung up, verify that call connection cannot be found.
            */
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(TestEnvironment.TargetUserId) };
                var options = new CreateCallOptions(new CallSource(user), targets, new Uri(TestEnvironment.AppCallbackUrl));
                CreateCallResult response = await client.CreateCallAsync(options).ConfigureAwait(false);
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);
                Assert.AreEqual(CallConnectionState.Connecting, response.CallConnectionProperties.CallConnectionState);
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;

                await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

                Assert.Fail("Call Connection should not be found after calling HangUp");
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && wasConnected)
                {
                    // call hung up successfully
                    Assert.Pass();
                }
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CreateCallToPSTNGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to PSTN call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one PSTN target.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call.
             * 5. once call is hung up, verify that call connection cannot be found.
            */
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user) {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };

                var targets = new CommunicationIdentifier[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
                var options = new CreateCallOptions(source, targets, new Uri(TestEnvironment.AppCallbackUrl));
                CreateCallResult response = await client.CreateCallAsync(options).ConfigureAwait(false);
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);
                Assert.AreEqual("connecting", response.CallConnectionProperties.CallConnectionState.ToString());
                await WaitForOperationCompletion().ConfigureAwait(false);

                Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;

                await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

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
        public async Task CreateCallWithMediaStreaming()
        {
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targetId = TestEnvironment.TargetUserId;
                var callBackUri = TestEnvironment.AppCallbackUrl;
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(targetId) };
                CreateCallOptions options = new CreateCallOptions(new CallSource(user), targets, new Uri(callBackUri))
                {
                    MediaStreamingOptions = new MediaStreamingOptions(
                        new Uri(TestEnvironment.WebsocketUrl),
                        MediaStreamingTransport.Websocket,
                        MediaStreamingContent.Audio,
                        MediaStreamingAudioChannel.Mixed)
                };
                CreateCallResult response = await client.CreateCallAsync(options).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                Assert.IsNotEmpty(response.CallConnectionProperties.CallConnectionId);
                Assert.AreEqual(CallConnectionState.Connecting, response.CallConnectionProperties.CallConnectionState);
                Assert.IsNotEmpty(response.CallConnectionProperties.MediaSubscriptionId);

                Response<CallConnectionProperties> properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);
                Assert.AreEqual(CallConnectionState.Connected, properties.Value.CallConnectionState);
                wasConnected = true;

                await response.CallConnection.HangUpAsync(true).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                properties = await response.CallConnection.GetCallConnectionPropertiesAsync().ConfigureAwait(false);

                Assert.Fail("Call Connection should not be found after calling HangUp");
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404 && wasConnected)
                {
                    // call hung up successfully
                    Assert.Pass();
                }
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CreateCallIdempotencyTest()
        {
            /* Test case: Create call is idempotent
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target with RepeatabilityHeaders set.
             * 3. send the exact same create call request again.
             * 4. compare call properties for both call results (should be the same).
             * 5. hang up the call.
            */
            if (SkipCallAutomationInteractionLiveTests)
                Assert.Ignore("Skip CallAutomation interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(TestEnvironment.TargetUserId) };
                var repeatabilityRequestId = new Guid("61460096-a0cc-4f65-8cec-b61cc24e646c");
                var repeatabilityFirstSent = "Wed, 21 Sep 2022 04:40:28 GMT";
                var options = new CreateCallOptions(new CallSource(user), targets, new Uri(TestEnvironment.AppCallbackUrl)) {
                    RepeatabilityRequestId = repeatabilityRequestId,
                    RepeatabilityFirstSent = repeatabilityFirstSent
                };
                CreateCallResult response1 = await client.CreateCallAsync(options).ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                CreateCallResult response2 = await client.CreateCallAsync(options).ConfigureAwait(false);

                Assert.AreEqual(response1.CallConnectionProperties.CallConnectionId, response2.CallConnectionProperties.CallConnectionId);
                Assert.AreEqual(response1.CallConnectionProperties.MediaSubscriptionId, response2.CallConnectionProperties.MediaSubscriptionId);

                await response1.CallConnection.HangUpAsync(true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
