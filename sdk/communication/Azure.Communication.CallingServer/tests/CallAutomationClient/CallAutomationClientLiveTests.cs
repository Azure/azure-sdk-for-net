// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Communication.CallingServer
{
    internal class CallAutomationClientLiveTests : CallAutomationClientLiveTestsBase
    {
        public CallAutomationClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task CreateCallToACSGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one ACS target.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call.
             * 5. once call is hung up, verify that call connection cannot be found.
            */
            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(TestEnvironment.TargetUserId) };
                CreateCallResult response = await client.CreateCallAsync(new CallSource(user), targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
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
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public async Task CreateCallToPSTNGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to PSTN call
             * 1. create a CallAutomationClient.
             * 2. create a call from source to one PSTN target.
             * 3. get updated call properties and check for the connected state.
             * 4. hang up the call.
             * 5. once call is hung up, verify that call connection cannot be found.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallAutomationClient client = CreateInstrumentedCallAutomationClientWithConnectionString();
            bool wasConnected = false;

            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var source = new CallSource(user) {
                    CallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)
                };

                var targets = new CommunicationIdentifier[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
                CreateCallResult response = await client.CreateCallAsync(source, targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
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
    }
}
