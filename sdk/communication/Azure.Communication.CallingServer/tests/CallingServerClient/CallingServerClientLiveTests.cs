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
            /* Test case: Acs to Acs call
             * 1. create a CallingServerClient using xPMA endpoint.
             * 2. create a call from source to one ACS target.
             * 3. use GetCall method to check for the connected state.
             * 4. hang up the call.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServer.CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

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

                await callConnection.HangupAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CreateCallToPSTNGetCallAndHangUpCallTest()
        {
            /* Test case: Acs to PSTN call
             * 1. create a CallingServerClient using xPMA endpoint.
             * 2. create a call from source to one PSTN target.
             * 3. use GetCall method to check for the connected state.
             * 4. hang up the call.
            */

            if (SkipCallingServerInteractionLiveTests)
                Assert.Ignore("Skip callingserver interaction live tests flag is on.");

            CallingServer.CallingServerClient client = CreateInstrumentedCallingServerClientWithConnectionString();

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

                await callConnection.HangupAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }
    }
}
