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
    public partial class Sample3_MemberOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread for members: add, get and remove members
        [Test]
        public async Task GetAddRemoveMembersAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUser> threadMember1 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUser> threadMember2 = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUser> threadMember3 = await communicationIdentityClient.CreateUserAsync();

            CommunicationUserToken communicationUserToken1 = await communicationIdentityClient.IssueTokenAsync(threadMember1.Value, new[] { CommunicationTokenScope.Chat });
            CommunicationUserToken communicationUserToken2 = await communicationIdentityClient.IssueTokenAsync(threadMember2.Value, new[] { CommunicationTokenScope.Chat });
            CommunicationUserToken communicationUserToken3 = await communicationIdentityClient.IssueTokenAsync(threadMember3.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken1.Token;
            string endpoint = TestEnvironment.ChatApiUrl();
            string theadCreatorMemberId = communicationUserToken1.User.Id;

            ChatClient chatClient = new ChatClient(
                new Uri(endpoint),
                new CommunicationUserCredential(userToken));

            var chatThreadMember = new ChatThreadMember(new CommunicationUser(theadCreatorMemberId))
            {
                DisplayName = "UserDisplayName",
                ShareHistoryTime = DateTime.MinValue
            };
            ChatThreadClient chatThreadClient = await chatClient.CreateChatThreadAsync(topic: "Hello world!", members: new[] { chatThreadMember });
            string threadId = chatThreadClient.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMembers
            AsyncPageable<ChatThreadMember> allMembers = chatThreadClient.GetMembersAsync();
            await foreach (ChatThreadMember member in allMembers)
            {
                Console.WriteLine($"{member.User.Id}:{member.DisplayName}:{member.ShareHistoryTime}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_GetMembers

            var memberId1 = theadCreatorMemberId;
            var memberId2 = communicationUserToken2.User.Id;
            var memberId3 = communicationUserToken3.User.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_AddMembers
            var members = new[]
            {
                new ChatThreadMember(new CommunicationUser(memberId1)) { DisplayName ="display name member 1"},
                new ChatThreadMember(new CommunicationUser(memberId2)) { DisplayName ="display name member 2"},
                new ChatThreadMember(new CommunicationUser(memberId3)) { DisplayName ="display name member 3"}
            };
            await chatThreadClient.AddMembersAsync(members);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_AddMembers

            var memberId = memberId2;
            #region Snippet:Azure_Communication_Chat_Tests_Samples_RemoveMember
            await chatThreadClient.RemoveMemberAsync(new CommunicationUser(memberId));
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_RemoveMember

            await chatClient.DeleteChatThreadAsync(threadId);

        }

        [Test]
        public void GetAddRemoveMembers()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUser> threadCreator = communicationIdentityClient.CreateUser();
            Response<CommunicationUser> threadMember2 = communicationIdentityClient.CreateUser();
            Response<CommunicationUser> threadMember3 = communicationIdentityClient.CreateUser();

            string userToken = communicationIdentityClient.IssueToken(threadCreator.Value, new[] { CommunicationTokenScope.Chat }).Value.Token;
            string endpoint = TestEnvironment.ChatApiUrl();

            ChatClient chatClient = new ChatClient(
                new Uri(endpoint),
                new CommunicationUserCredential(userToken));

            var chatThreadMember = new ChatThreadMember(new CommunicationUser(threadCreator.Value.Id))
            {
                DisplayName = "UserDisplayName",
                ShareHistoryTime = DateTime.MinValue
            };
            ChatThreadClient chatThreadClient = chatClient.CreateChatThread(topic: "Hello world!", members: new[] { chatThreadMember });

            Pageable<ChatThreadMember> allMembers = chatThreadClient.GetMembers();
            foreach (ChatThreadMember member in allMembers)
            {
                Console.WriteLine($"{member.User.Id}:{member.DisplayName}:{member.ShareHistoryTime}");
            }

            var members = new[]
            {
                new ChatThreadMember(threadCreator) { DisplayName ="display name thread creator"},
                new ChatThreadMember(threadMember2) { DisplayName ="display name member 2"},
                new ChatThreadMember(threadMember3) { DisplayName ="display name member 3"}
            };
            chatThreadClient.AddMembers(members);

            chatThreadClient.RemoveMember(new CommunicationUser(threadMember2.Value.Id));

            chatClient.DeleteChatThread(chatThreadClient.Id);
        }
    }
}
