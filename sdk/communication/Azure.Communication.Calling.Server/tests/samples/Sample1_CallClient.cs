// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Calling.Server.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_CallClient : ServerCallingLiveTestBase
    {
        public Sample1_CallClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task CreateCallAsync()
        {
            var sourceIdentity = await ServerCallingClientsLiveTests.CreateUserAsync(TestEnvironment.LiveTestConnectionString).ConfigureAwait(false);
            var source = new CommunicationUserIdentifier(sourceIdentity.Id);
            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });

            CallClient callClient = CreateServerCallingClient();
            Console.WriteLine("Performing CreateCall operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCallAsync
            CreateCallResponse createCallResponse = await callClient.CreateCallAsync(
                //@@ source: "<source-identifier>", // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: "<targets-phone-number>", // E.164 formatted recipient phone number
                //@@ callOptions: "<callOptions-object>", // The request payload for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ callOptions: createCallOption);
            Console.WriteLine($"Call Leg id: {createCallResponse.CallLegId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCallAsync
        }

        [Test]
        [SyncOnly]
        public void CreateCall()
        {
            var sourceIdentity = ServerCallingClientsLiveTests.CreateUser(TestEnvironment.LiveTestConnectionString);
            var source = new CommunicationUserIdentifier(sourceIdentity.Id);
            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> { EventSubscriptionType.ParticipantsUpdated, EventSubscriptionType.DtmfReceived });

            CallClient callClient = CreateServerCallingClient();
            Console.WriteLine("Performing CreateCall operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCall
            CreateCallResponse createCallResponse = callClient.CreateCall(
                //@@ source: "<source-identifier>", // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: "<targets-phone-number>", // E.164 formatted recipient phone number
                //@@ callOptions: "<callOptions-object>", // The request payload for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ callOptions: createCallOption);
            Console.WriteLine($"Call Leg id: {createCallResponse.CallLegId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCall
        }
    }
}
