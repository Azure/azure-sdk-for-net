// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.CallingServer.Models;
using Azure.Communication.CallingServer.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.CallingServerClient
{
    internal class CallingServerClientLiveTests : CallingServerClientLiveTestsBase
    {
        public CallingServerClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateCallToACSGetCallAndHangUpCallTest()
        {
            /* Test case: ACS to ACS call
             * 1. create a CallingServerClient.
             * 2. create a call from source to one ACS target.
             * 3. use GetCall method to check for the connected state.
             * 4. hang up the call.
             * 5. use GetCall method to check for 404 Not Found once call is hung up.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServer.CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            bool wasConnected = false;
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targets = new CommunicationIdentifier[] { new CommunicationUserIdentifier(TestEnvironment.TargetUserId) };
                CallConnection callConnection = await client.CreateCallAsync(new CallSource(user), targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                var callConnectionId = callConnection.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);
                Assert.AreEqual("connecting", callConnection.CallConnectionState.ToString());
                await WaitForOperationCompletion().ConfigureAwait(false);

                CallConnection updatedCallConnection = await client.GetCallAsync(callConnectionId).ConfigureAwait(false);
                Assert.AreEqual("connected", updatedCallConnection.CallConnectionState.ToString());
                wasConnected = true;

                await callConnection.HangupAsync().ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                await client.GetCallAsync(callConnectionId).ConfigureAwait(false);
                Assert.Fail("Call connection should not be found after hanging up.");
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
             * 1. create a CallingServerClient.
             * 2. create a call from source to one PSTN target.
             * 3. use GetCall method to check for the connected state.
             * 4. hang up the call.
             * 5. use GetCall method to check for 404 Not Found once call is hung up.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServer.CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();
            bool wasConnected = false;
            try
            {
                var user = await CreateIdentityUserAsync().ConfigureAwait(false);
                var targets = new CommunicationIdentifier[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
                CallConnection callConnection = await client.CreateCallAsync(new CallSource(user,new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber)), targets, new Uri(TestEnvironment.AppCallbackUrl)).ConfigureAwait(false);
                var callConnectionId = callConnection.CallConnectionId;
                Assert.IsNotEmpty(callConnectionId);
                Assert.AreEqual("connecting", callConnection.CallConnectionState.ToString());
                await WaitForOperationCompletion(20000).ConfigureAwait(false);

                CallConnection updatedCallConnection = await client.GetCallAsync(callConnectionId).ConfigureAwait(false);
                Assert.AreEqual("connected", updatedCallConnection.CallConnectionState.ToString());
                wasConnected = true;

                await callConnection.HangupAsync().ConfigureAwait(false);
                await WaitForOperationCompletion().ConfigureAwait(false);
                await client.GetCallAsync(callConnectionId).ConfigureAwait(false);
                Assert.Fail("Call connection should not be found after hanging up.");
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
