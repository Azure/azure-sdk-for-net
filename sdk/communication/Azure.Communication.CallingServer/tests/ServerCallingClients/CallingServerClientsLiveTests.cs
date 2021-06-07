// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using System;
using System.Collections.Generic;
//@@ using Azure.Communication.CallingServer;
#endregion Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using Azure.Communication.Identity;

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CallClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class CallingServerClientsLiveTests : CallingServerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public CallingServerClientsLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateCallTest()
        {
            CallClient client = CreateInstrumentedCallingServerClient();
            try
            {
                await CreateCallOperation(client).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task DeteleCallTest()
        {
            CallClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await DeteleCallOperation(client, callLegId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task PlayAudioTest()
        {
            CallClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(client, callLegId).ConfigureAwait(false);

                await DeteleCallOperation(client, callLegId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task HangupCallTest()
        {
            CallClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                // There is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(client, callLegId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task CancelAllMediaOperationsTest()
        {
            CallClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(client, callLegId).ConfigureAwait(false);

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CancelAllMediaOperationsOperation(client, callLegId).ConfigureAwait(false);

                await DeteleCallOperation(client, callLegId).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        #region Support functions
        #region Snippet:Azure_Communication_ServerCalling_Tests_CreateCallOperation
        private async Task<Response<CreateCallResponse>> CreateCallOperation(CallClient client)
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = await CreateUserAsync(communicationIdentityClient).ConfigureAwait(false);

            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var createCallResponse = await client.CreateCallAsync(source: source, targets: targets, options: createCallOption).ConfigureAwait(false);

            Console.WriteLine("Call initiated with Call Leg id: {0}", createCallResponse.Value.CallLegId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(createCallResponse.Value.CallLegId));
            return createCallResponse;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_DeteleCallOperation
        private async Task DeteleCallOperation(CallClient client, string callLegId)
        {
            var response = await client.DeleteCallAsync(callLegId: callLegId).ConfigureAwait(false);

            Console.WriteLine("Delete Call with Call Leg id: {0}", callLegId);

            Assert.AreEqual(202, response.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.ClientRequestId));
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_DeteleCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation
        private async Task PlayAudioOperation(CallClient client, string callLegId)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                AudioFileUri = new Uri(TestEnvironment.AudioFileUrl),
                OperationContext = "de346f03-7f8d-41ab-a232-cc5e14990769",
                Loop = true,
                AudioFileId = "ebb1d98d-fd86-4204-800c-f7bdfc2e515c"
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await client.PlayAudioAsync(callLegId, playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation
        private async Task HangupOperation(CallClient client, string callLegId)
        {
            Console.WriteLine("Performing Hangup operation");

            var response = await client.HangupCallAsync(callLegId).ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation
        private async Task CancelAllMediaOperationsOperation(CallClient client, string callLegId)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var response = await client.CancelAllMediaOperationsAsync(callLegId).ConfigureAwait(false);

            Assert.AreEqual(OperationStatus.Completed, response.Value.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation

        #endregion

        #region Support functions
        private CommunicationUserIdentifier CreateUser(CommunicationIdentityClient communicationIdentityClient)
        {
            // reserve for living test, expect adding more content in the future.
            return communicationIdentityClient.CreateUser();
        }

        private async Task<CommunicationUserIdentifier> CreateUserAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            // reserve for living test, expect adding more content in the future.
            return await communicationIdentityClient.CreateUserAsync();
        }
        #endregion Support functions
    }
}
