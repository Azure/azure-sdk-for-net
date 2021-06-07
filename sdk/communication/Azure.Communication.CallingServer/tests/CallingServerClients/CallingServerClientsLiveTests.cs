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
        [Ignore("Ignore for now as we get build errors that block checkingin.")]
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
        [Ignore("Ignore for now as we get build errors that block checkingin.")]
        public async Task DeteleCallTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await DeteleCallOperation(callConnection).ConfigureAwait(false);
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
        [Ignore("PlayAudio Operation required the call is under established state which is not doable for now.")]
        public async Task PlayAudioTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await PlayAudioOperation(callConnection).ConfigureAwait(false);
                await DeteleCallOperation(callConnection).ConfigureAwait(false);
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
        [Ignore("Ignore for now as we get build errors that block checkingin.")]
        public async Task HangupCallTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await HangupOperation(callConnection).ConfigureAwait(false);
                await DeteleCallOperation(callConnection).ConfigureAwait(false);
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
        [Ignore("CancelMediaOperations Operation required the call is under established state which is not doable for now.")]
        public async Task CancelMediaOperationsTest()
        {
            CallingServerClient client = CreateInstrumentedCallingServerClient();
            try
            {
                var callConnection = await CreateCallOperation(client).ConfigureAwait(false);

                await CancelMediaOperationsOperation(callConnection).ConfigureAwait(false);
                await DeteleCallOperation(callConnection).ConfigureAwait(false);
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

            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var callConnection = await client.CreateCallConnectionAsync(source: source, targets: targets, options: createCallOption).ConfigureAwait(false);

            Assert.IsFalse(string.IsNullOrWhiteSpace(callConnection.Value.CallConnectionId));

            Console.WriteLine("Call initiated with Call Leg id: {0}", callConnection.Value.CallConnectionId);

            return callConnection;
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CreateCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_DeteleCallOperation
        private async Task DeteleCallOperation(CallConnection client)
        {
            var response = await client.DeleteAsync().ConfigureAwait(false);

            Console.WriteLine("Delete Call with Call Leg id: {0}", client.CallConnectionId);

            Assert.AreEqual(202, response.Status);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response.ClientRequestId));
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_DeteleCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation
        private async Task PlayAudioOperation(CallConnection client)
        {
            var playAudioOptions = new PlayAudioOptions()
            {
                AudioFileUri = new Uri(TestEnvironment.AudioFileUrl),
                OperationContext = Guid.NewGuid().ToString(),
                Loop = true,
                AudioFileId = Guid.NewGuid().ToString()
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await client.PlayAudioAsync(playAudioOptions).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_PlayAudioOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation
        private async Task HangupOperation(CallConnection client)
        {
            Console.WriteLine("Performing Hangup operation");

            var response = await client.HangupAsync().ConfigureAwait(false);

            Assert.AreEqual(202, response.Status);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_HangupCallOperation

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation
        private async Task CancelMediaOperationsOperation(CallConnection client)
        {
            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var response = await client.CancelAllMediaOperationsAsync().ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
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
