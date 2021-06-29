// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task CreateCallAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = await communicationIdentityClient.CreateUserAsync();
            var targets = new[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
            #region Snippet:Azure_Communication_Call_Tests_CreateCallOptions
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new[] { MediaType.Audio },
                   new[]
                   {
                       EventSubscriptionType.ParticipantsUpdated,
                       EventSubscriptionType.DtmfReceived
                   });
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCallOptions
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            Console.WriteLine("Performing CreateCallConnection operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCallAsync
            var callConnection = await callingServerClient.CreateCallConnectionAsync(
                //@@ source: new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
                //@@ options: createCallOption // The options for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ options: createCallOption
                );
            Console.WriteLine($"Call connection id: {callConnection.Value.CallConnectionId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCallAsync
        }

        [Test]
        [SyncOnly]
        public void CreateCall()
        {
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            var source = communicationIdentityClient.CreateUser();
            var targets = new[] { new PhoneNumberIdentifier(TestEnvironment.TargetPhoneNumber) };
            var createCallOption = new CreateCallOptions(
                   new Uri(TestEnvironment.AppCallbackUrl),
                   new[] { MediaType.Audio },
                   new[] {
                       EventSubscriptionType.ParticipantsUpdated,
                       EventSubscriptionType.DtmfReceived
                   });
            CallingServerClient callingServerClient = CreateInstrumentedCallingServerClient();
            Console.WriteLine("Performing CreateCallConnection operation");
            #region Snippet:Azure_Communication_Call_Tests_CreateCall
            var callConnection = callingServerClient.CreateCallConnection(
                //@@ source: new CommunicationUserIdentifier("<source-identifier>"), // Your Azure Communication Resource Guid Id used to make a Call
                //@@ targets: new List<CommunicationIdentifier>() { new PhoneNumberIdentifier("<targets-phone-number>") }, // E.164 formatted recipient phone number
                //@@ options: createCallOption // The options for creating a call.
                /*@@*/ source: source,
                /*@@*/ targets: targets,
                /*@@*/ options: createCallOption
                );
            Console.WriteLine($"Call connection id: {callConnection.Value.CallConnectionId}");
            #endregion Snippet:Azure_Communication_Call_Tests_CreateCall
        }
    }
}
