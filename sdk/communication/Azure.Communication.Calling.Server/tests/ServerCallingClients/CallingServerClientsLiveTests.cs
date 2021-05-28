// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using System;
using System.Collections.Generic;
//@@ using Azure.Communication.Calling.Server;
#endregion Snippet:Azure_Communication_ServerCalling_Tests_UsingStatements
using Azure.Communication.Identity;

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.Communication.Calling.Server.Tests
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
            CallClient client = CreateServerCallingClient();
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
            CallClient client = CreateServerCallingClient();
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
        [Ignore("PlayAudio Operation required the call is under established state which is not doable for now.")]
        public async Task PlayAudioTest()
        {
            CallClient client = CreateServerCallingClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

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
            CallClient client = CreateServerCallingClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await HangupOperation(client, callLegId).ConfigureAwait(false);
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
        [Ignore("CancelMediaOperations Operation required the call is under established state which is not doable for now.")]
        public async Task CancelMediaOperationsTest()
        {
            CallClient client = CreateServerCallingClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await CancelMediaOperationsOperation(client, callLegId).ConfigureAwait(false);
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
            var sourceIdentity = await CreateUserAsync(TestEnvironment.LiveTestStaticConnectionString).ConfigureAwait(false);
            var source = new CommunicationUserIdentifier(sourceIdentity.Id);
            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });
            createCallOption.AlternateCallerId = new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber);

            Console.WriteLine("Performing CreateCall operation");

            var createCallResponse = await client.CreateCallAsync(source: source, targets: targets, callOptions: createCallOption).ConfigureAwait(false);

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
            var playAudioRequest = new PlayAudioRequest()
            {
                AudioFileUri = TestEnvironment.AudioFileUrl,
                OperationContext = Guid.NewGuid().ToString(),
                Loop = true,
                AudioFileId = Guid.NewGuid().ToString()
            };

            Console.WriteLine("Performing PlayAudio operation");

            var response = await client.PlayAudioAsync(callLegId, playAudioRequest).ConfigureAwait(false);

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
        private async Task CancelMediaOperationsOperation(CallClient client, string callLegId)
        {
            var playAudioRequest = new PlayAudioRequest()
            {
                AudioFileUri = TestEnvironment.AudioFileUrl,
                OperationContext = Guid.NewGuid().ToString(),
                Loop = true,
                AudioFileId = Guid.NewGuid().ToString()
            };

            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var operationContext = Guid.NewGuid().ToString();
            var response = await client.CancelMediaOperationsAsync(callLegId).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaOperationsOperation

        #endregion

        #region Support functions
        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="connectionString">The connectionstring of Azure Communication Service resource.</param>
        /// <returns></returns>
        public static async Task<CommunicationUserIdentifier> CreateUserAsync(string connectionString)
        {
            var client = new CommunicationIdentityClient(connectionString);
            var user = await client.CreateUserAsync().ConfigureAwait(false);
            return user.Value;
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="connectionString">The connectionstring of Azure Communication Service resource.</param>
        /// <returns></returns>
        public static CommunicationUserIdentifier CreateUser(string connectionString)
        {
            var client = new CommunicationIdentityClient(connectionString);
            var user = client.CreateUser();
            return user.Value;
        }
        #endregion Support functions
    }
}
