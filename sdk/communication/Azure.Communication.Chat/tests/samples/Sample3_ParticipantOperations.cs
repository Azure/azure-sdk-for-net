// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Administration;
using Azure.Communication.Administration.Models;
using Azure.Communication.Identity;
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
            Response<CommunicationUser> user1 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUser> user2 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUser> user3 = await communicationIdentityClient.CreateUserAsync();

            CommunicationUserToken communicationUserToken1 = await communicationIdentityClient.IssueTokenAsync(user1.Value, new[] { CommunicationTokenScope.Chat });
            CommunicationUserToken communicationUserToken2 = await communicationIdentityClient.IssueTokenAsync(user2.Value, new[] { CommunicationTokenScope.Chat });
            CommunicationUserToken communicationUserToken3 = await communicationIdentityClient.IssueTokenAsync(user3.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken1.Token;
            string endpoint = TestEnvironment.ChatApiUrl();
            string theadCreatorUserId = communicationUserToken1.User.Id;

            ChatClient chatClient = new ChatClient(
                new Uri(endpoint),
                new CommunicationUserCredential(userToken));

            var chatParticipant = new ChatParticipant(new CommunicationUser(theadCreatorUserId))
            {
                DisplayName = "UserDisplayName",
                ShareHistoryTime = DateTime.MinValue
            };
            ChatThreadClient chatThreadClient = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant });
            string threadId = chatThreadClient.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants
            AsyncPageable<ChatParticipant> allParticipants = chatThreadClient.GetParticipantsAsync();
            await foreach (ChatParticipant participant in allParticipants)
            {
                Console.WriteLine($"{participant.User.Id}:{participant.DisplayName}:{participant.ShareHistoryTime}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_GetMembers

            var participantId1 = theadCreatorUserId;
            var participantId2 = communicationUserToken2.User.Id;
            var participantId3 = communicationUserToken3.User.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants
            var participants = new[]
            {
                new ChatParticipant(new CommunicationUser(participantId1)) { DisplayName ="display name participant 1"},
                new ChatParticipant(new CommunicationUser(participantId2)) { DisplayName ="display name participant 2"},
                new ChatParticipant(new CommunicationUser(participantId3)) { DisplayName ="display name participant 3"}
            };
            await chatThreadClient.AddParticipantsAsync(participants);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants

            var participantId = participantId2;
            #region Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant
            await chatThreadClient.RemoveParticipantAsync(new CommunicationUser(participantId));
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant

            await chatClient.DeleteChatThreadAsync(threadId);

        }
    }
}
