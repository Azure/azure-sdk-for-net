// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
#region Snippet:Azure_Communication_Chat_Tests_E2E_UsingStatements
using Azure.Communication.Administration;
using Azure.Communication.Administration.Models;
using Azure.Communication.Identity;
//@@ using Azure.Communication.Chat;
#endregion Snippet:Azure_Communication_Chat_Tests_E2E_UsingStatements

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ChatClient"/> and <see cref="ChatThreadClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ChatClientsTest : ChatLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ChatClientsTest(bool isAsync) : base(isAsync)
        {
        }

        [SyncOnly]
        [Test]
        public void E2E_ThreadCreateUpdateGetDelete_MemberAddUpdateRemove_MessageGetSendUpdate_NotificationTyping_ReadReceiptGetSend()
        {
            //arr
            CommunicationUser user1, user2, user3;
            string token1, token2, token3;
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (user1, token1) = CreateUserAndToken(communicationIdentityClient);
            (user2, token2) = CreateUserAndToken(communicationIdentityClient);
            (user3, token3) = CreateUserAndToken(communicationIdentityClient);

            var topic = "Thread sync from C# sdk";
            var messageContent = "This is message 1 content";
            var updatedMessageContent = "This is message 1 content updated";
            var displayNameMessage = "DisplayName sender message 1";
            var updatedTopic = "Updated topic - C# sdk";
            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            #region Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            //@@ChatThreadClient chatThreadClient1 = chatClient.CreateChatThread("Thread topic", members);
            // Alternatively, if you have created a chat thread before and you have its threadId, you can create a ChatThreadClient instance using:
            //@@ChatThreadClient chatThreadClient2 = chatClient.GetChatThreadClient("threadId");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            ChatThreadClient chatThreadClient = CreateInstrumentedChatThreadClient(chatClient, topic, members);
            ChatThreadClient chatThreadClient2 = CreateInstrumentedChatThreadClient(chatClient, topic, members);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread
            chatThreadClient.UpdateThread("Updated topic - C# sdk");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread

            var threadId = chatThreadClient.Id;
            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThread
            ChatThread chatThread = chatClient.GetChatThread(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThread

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThreadsInfo
            Pageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfo();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThreadsInfo
            var threadsCount = threads.Count();

            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("This is message 1 content", ChatMessagePriority.High, displayNameMessage);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            SendChatMessageResult sendChatMessageResult2 = chatThreadClient.SendMessage(messageContent, ChatMessagePriority.High, displayNameMessage);

            var messageId = sendChatMessageResult.Id;
            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage
            ChatMessage message = chatThreadClient.GetMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            var getMessagesCount = messages.Count();

            #region Snippet:Azure_Communication_Chat_Tests_E2E_UpdateMessage
            chatThreadClient.UpdateMessage(messageId, "This is message 1 content updated");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_UpdateMessage
            Response<ChatMessage> actualUpdateMessage = chatThreadClient.GetMessage(messageId);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_DeleteMessage
            chatThreadClient.DeleteMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_DeleteMessage
            Pageable<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessages();
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.First(x => x.Id == messageId);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMembers
            Pageable<ChatThreadMember> chatThreadMembers = chatThreadClient.GetMembers();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMembers
            var chatThreadMembersCount = chatThreadMembers.Count();

            var newMember = new ChatThreadMember(user3);
            #region Snippet:Azure_Communication_Chat_Tests_E2E_AddMembers
            chatThreadClient.AddMembers(members: new[] { newMember });
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_AddMembers
            Pageable<ChatThreadMember> chatThreadMembersAfterOneAdded = chatThreadClient.GetMembers();
            var chatThreadMembersAfterOneAddedCount = chatThreadMembersAfterOneAdded.Count();

            CommunicationUser memberToBeRemoved = user3; //Better name for the snippet
            #region Snippet:Azure_Communication_Chat_Tests_E2E_RemoveMember
            chatThreadClient.RemoveMember(user: memberToBeRemoved);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_RemoveMember
            Pageable<ChatThreadMember> chatThreadMembersAfterOneDeleted = chatThreadClient.GetMembers();
            var chatThreadMembersAfterOneDeletedCount = chatThreadMembersAfterOneDeleted.Count();

            Response typingNotificationResponse = chatThreadClient.SendTypingNotification();
            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification
            chatThreadClient.SendTypingNotification();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification

            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient.SendReadReceipt(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient.SendReadReceipt(sendChatMessageResult2.Id);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            Pageable<ReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            var readReceiptsCount = readReceipts.Count();

            #region Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread
            chatClient.DeleteChatThread(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(2, chatThread.Members.Count);
            Assert.AreEqual(messageContent, message.Content);
            Assert.AreEqual(displayNameMessage, message.SenderDisplayName);
            Assert.AreEqual(ChatMessagePriority.High, message.Priority);
            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(5, getMessagesCount); //Including all types
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(2, chatThreadMembersCount);
            Assert.AreEqual(3, chatThreadMembersAfterOneAddedCount);
            Assert.AreEqual(2, chatThreadMembersAfterOneDeletedCount);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationResponse.Status);
            // TODO: Commenting out the assert below for now as it is flakey due to server-side delay; currently in investigation
            // Assert.AreEqual(1, readReceiptsCount);
        }

        [AsyncOnly]
        [Test]
        public async Task E2E_ThreadCreateUpdateGetDelete_MemberAddUpdateRemove_MessageGetSendUpdate_NotificationTyping_ReadReceiptGetSend_Async()
        {
            //arr
            CommunicationUser user1, user2, user3;
            string token1, token2, token3;
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (user1, token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (user2, token2) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (user3, token3) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var topic = "Thread Async from C# sdk";
            var contentMessage = "This is message 1";
            var updatedMessageContent = "This is message 1 updated";
            var displayNameMessage = "DisplayName sender message 1";
            var updatedTopic = "Updated topic - C# sdk";
            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            ChatThreadClient chatThreadClient = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, members);
            ChatThreadClient chatThreadClient2 = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, members);
            await chatThreadClient.UpdateThreadAsync(updatedTopic);

            ChatThread chatThread = await chatClient.GetChatThreadAsync(chatThreadClient.Id);

            AsyncPageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfoAsync();
            var threadsCount = threads.ToEnumerableAsync().Result.Count;

            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(contentMessage, ChatMessagePriority.High, displayNameMessage);
            SendChatMessageResult sendChatMessageResult2 = await chatThreadClient.SendMessageAsync(contentMessage, ChatMessagePriority.High, displayNameMessage);

            ChatMessage message = await chatThreadClient.GetMessageAsync(sendChatMessageResult.Id);

            AsyncPageable<ChatMessage> messages = chatThreadClient.GetMessagesAsync();
            var getMessagesCount = messages.ToEnumerableAsync().Result.Count;

            var messageId = sendChatMessageResult.Id;
            await chatThreadClient.UpdateMessageAsync(messageId, updatedMessageContent);
            Response<ChatMessage> actualUpdateMessage = await chatThreadClient.GetMessageAsync(messageId);

            await chatThreadClient.DeleteMessageAsync(messageId);
            AsyncPageable<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessagesAsync();
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.ToEnumerableAsync().Result.First(x => x.Id == messageId);

            AsyncPageable<ChatThreadMember> chatThreadMembers = chatThreadClient.GetMembersAsync();
            var chatThreadMembersCount = chatThreadMembers.ToEnumerableAsync().Result.Count;

            var newMember = new ChatThreadMember(user3);
            await chatThreadClient.AddMembersAsync(new List<ChatThreadMember> { newMember });
            AsyncPageable<ChatThreadMember> chatThreadMembersAfterOneAdded = chatThreadClient.GetMembersAsync();
            var chatThreadMembersAfterOneAddedCount = chatThreadMembersAfterOneAdded.ToEnumerableAsync().Result.Count();

            CommunicationUser userToBeRemoved = user3; //Better name for the snippet
            await chatThreadClient.RemoveMemberAsync(userToBeRemoved);
            AsyncPageable<ChatThreadMember> chatThreadMembersAfterOneDeleted = chatThreadClient.GetMembersAsync();
            var chatThreadMembersAfterOneDeletedCount = chatThreadMembersAfterOneDeleted.ToEnumerableAsync().Result.Count();

            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();
            await chatThreadClient.SendTypingNotificationAsync();

            await chatThreadClient.SendReadReceiptAsync(messageId);
            await chatThreadClient.SendReadReceiptAsync(sendChatMessageResult2.Id);

            AsyncPageable<ReadReceipt> readReceipts = chatThreadClient.GetReadReceiptsAsync();
            var readReceiptsCount = readReceipts.ToEnumerableAsync().Result.Count();

            await chatClient.DeleteChatThreadAsync(chatThreadClient.Id);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(2, chatThread.Members.Count);
            Assert.AreEqual(contentMessage, message.Content);
            Assert.AreEqual(displayNameMessage, message.SenderDisplayName);
            Assert.AreEqual(ChatMessagePriority.High, message.Priority);
            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(5, getMessagesCount); //Including all types
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(2, chatThreadMembersCount);
            Assert.AreEqual(3, chatThreadMembersAfterOneAddedCount);
            Assert.AreEqual(2, chatThreadMembersAfterOneDeletedCount);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationResponse.Status);
            //TODO: Commenting out the assert below for now as it is flakey due to server-side delay; currently in investigation
            // Assert.AreEqual(1, readReceiptsCount);
        }

        private (CommunicationUser user, string token) CreateUserAndToken(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUser> threadMember = communicationIdentityClient.CreateUser();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseThreadMember = communicationIdentityClient.IssueToken(threadMember.Value, scopes);

            return (tokenResponseThreadMember.Value.User, tokenResponseThreadMember.Value.Token);
        }

        private async Task<(CommunicationUser user, string token)> CreateUserAndTokenAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUser> threadMember = await communicationIdentityClient.CreateUserAsync();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseThreadMember = await communicationIdentityClient.IssueTokenAsync(threadMember.Value, scopes);

            return (tokenResponseThreadMember.Value.User, tokenResponseThreadMember.Value.Token);
        }
    }
}
