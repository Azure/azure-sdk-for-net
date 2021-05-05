// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Communication.Identity;

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="CallClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ServerCallingClientsLiveTests : ServerCallingLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ServerCallingClientsLiveTests(bool isAsync) : base(isAsync)
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
        public async Task CancelMediaProcessingTest()
        {
            CallClient client = CreateServerCallingClient();
            try
            {
                var createCallResponse = await CreateCallOperation(client).ConfigureAwait(false);
                var callLegId = createCallResponse.Value.CallLegId;

                await CancelMediaProcessingOperation(client, callLegId).ConfigureAwait(false);
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
            var source = new CommunicationUserIdentifier(TestEnvironment.SourceIdentity);
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
                ResourceId = Guid.NewGuid().ToString()
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

        #region Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaProcessingOperation
        private async Task CancelMediaProcessingOperation(CallClient client, string callLegId)
        {
            var playAudioRequest = new PlayAudioRequest()
            {
                AudioFileUri = TestEnvironment.AudioFileUrl,
                OperationContext = Guid.NewGuid().ToString(),
                Loop = true,
                ResourceId = Guid.NewGuid().ToString()
            };

            Console.WriteLine("Performing cancel media processing operation to stop playing audio");

            var operationContext = Guid.NewGuid().ToString();
            var response = await client.CancelMediaProcessingAsync(callLegId, operationContext).ConfigureAwait(false);

            Assert.AreEqual(response.Value.Status, OperationStatus.Running);
        }
        #endregion Snippet:Azure_Communication_ServerCalling_Tests_CancelMediaProcessingOperation

        #endregion
    }
}
