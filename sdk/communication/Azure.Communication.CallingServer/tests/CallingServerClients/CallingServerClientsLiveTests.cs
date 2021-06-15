// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.Identity;

using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CallConnection"/> class.
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
        [Ignore("fix later")]
        public async Task CreateCallTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
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
        public async Task PlayAudioTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(callConnection).ConfigureAwait(false);

                await HangupOperation(callConnection).ConfigureAwait(false);
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
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                // There is one call leg in this test case, hangup the call will also delete the call as the result.
                await HangupOperation(callConnection).ConfigureAwait(false);
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
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await PlayAudioOperation(callConnection).ConfigureAwait(false);

                await SleepIfNotInPlaybackModeAsync().ConfigureAwait(false);
                await CancelAllMediaOperationsOperation(callConnection).ConfigureAwait(false);

                await HangupOperation(callConnection).ConfigureAwait(false);
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
        private async Task<Response<CallConnection>> CreateCallOperation(CallingServerClient client)
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = await CreateUserAsync(communicationIdentityClient).ConfigureAwait(false);

            var targets = new[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new[] { MediaType.Audio },
                   new[] { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var callConnection = await client.CreateCallConnectionAsync(source: source, targets: targets, options: createCallOption).ConfigureAwait(false);

            Console.WriteLine("Call initiated with Call connection id: {0}", callConnection.Value.CallConnectionId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(callConnection.Value.CallConnectionId));
            return callConnection;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation
        private async Task PlayAudioOperation(CallConnection callConnection)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                AudioFileUri = new Uri(TestEnvironment.AudioFileUrl),
                OperationContext = "de346f03-7f8d-41ab-a232-cc5e14990769",
                Loop = true,
                AudioFileId = "ebb1d98d-fd86-4204-800c-f7bdfc2e515c"
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await callConnection.PlayAudioAsync(playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation
        private async Task HangupOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing Hangup operation");

            var response = await callConnection.HangupAsync().ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation
        private async Task CancelAllMediaOperationsOperation(CallConnection callConnection)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var response = await callConnection.CancelAllMediaOperationsAsync().ConfigureAwait(false);

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
