// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_CallClient : CallingServerLiveTestBase
    {
        public Sample1_CallClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        [Ignore("Ignore for now as we get build errors that block checkingin.")]
        public async Task CreateCallAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.LiveTestDynamicConnectionString);
            var source = await communicationIdentityClient.CreateUserAsync();
            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            #region Snippet:Azure_Communication_Call_Tests_CreateCallOptions
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType>
                   {
                       EventSubscriptionType.ParticipantsUpdated,
                       EventSubscriptionType.DtmfReceived
                   });
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCallOptions
            CallClient callClient = CreateInstrumentedCallingServerClient();
            Console.WriteLine("Performing CreateCall operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCallAsync
            CreateCallResponse createCallResponse = await callClient.CreateCallAsync(
                //@@ source: new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
                //@@ options: createCallOption // The options for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ options: createCallOption
                );
            Console.WriteLine($"Call Leg id: {createCallResponse.CallLegId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCallAsync
        }

        [Test]
        [SyncOnly]
        [Ignore("Ignore for now as we get build errors that block checkingin.")]
        public void CreateCall()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.LiveTestDynamicConnectionString);
            var source = communicationIdentityClient.CreateUser();
            var targets = new List<CommunicationIdentifier>() { new PhoneNumberIdentifier(TestEnvironment.SourcePhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new List<CallModality> { CallModality.Audio },
                   new List<EventSubscriptionType> {
                       EventSubscriptionType.ParticipantsUpdated,
                       EventSubscriptionType.DtmfReceived
                   });
            CallClient callClient = CreateInstrumentedCallingServerClient();
            Console.WriteLine("Performing CreateCall operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCall
            CreateCallResponse createCallResponse = callClient.CreateCall(
                //@@ source: new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
                //@@ options: createCallOption // The options for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ options: createCallOption
                );
            Console.WriteLine($"Call Leg id: {createCallResponse.CallLegId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCall
        }
    }
}
