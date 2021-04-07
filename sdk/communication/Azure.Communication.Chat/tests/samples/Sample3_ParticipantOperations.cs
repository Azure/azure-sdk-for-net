// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample3_ParticipantOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread for participants: add, get and remove participants
        [Test]
        public async Task GetAddRemoveMembersAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> joshResponse = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier josh = joshResponse.Value;
            Response<CommunicationUserIdentifier> gloriaResponse = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier gloria = gloriaResponse.Value;
            Response<CommunicationUserIdentifier> amyResponse = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserIdentifier amy = amyResponse.Value;

            AccessToken joshTokenResponse = await communicationIdentityClient.GetTokenAsync(josh, new[] { CommunicationTokenScope.Chat });

            ChatClient chatClient = new ChatClient(
                TestEnvironment.Endpoint,
                new CommunicationTokenCredential(joshTokenResponse.Token));

            var chatParticipant = new ChatParticipant(josh)
            {
                DisplayName = "Josh",
                ShareHistoryTime = DateTime.MinValue
            };
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant });
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(createChatThreadResult.ChatThread.Id);

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants
            AsyncPageable<ChatParticipant> allParticipants = chatThreadClient.GetParticipantsAsync();
            await foreach (ChatParticipant participant in allParticipants)
            {
                Console.WriteLine($"{((CommunicationUserIdentifier)participant.User).Id}:{participant.DisplayName}:{participant.ShareHistoryTime}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_GetMembers

            #region Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants
            var participants = new[]
            {
                new ChatParticipant(josh) { DisplayName = "Josh" },
                new ChatParticipant(gloria) { DisplayName = "Gloria" },
                new ChatParticipant(amy) { DisplayName = "Amy" }
            };

            await chatThreadClient.AddParticipantsAsync(participants);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants

            #region Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant
            await chatThreadClient.RemoveParticipantAsync(gloria);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant

            await chatClient.DeleteChatThreadAsync(chatThreadClient.Id);
        }
    }
}
