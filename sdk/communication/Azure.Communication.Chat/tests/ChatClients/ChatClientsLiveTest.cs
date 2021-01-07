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
using Azure.Communication;
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
    public class ChatClientsLiveTest : ChatLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ChatClientsLiveTest(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Thread      : Create, Get, Update, Delete
        /// Member      : Add, Update, Remove
        /// Message     : Get, Send, update
        /// Notification: Typing
        /// </summary>
        [SyncOnly]
        [Test]
        public void ThreadCGUD_MemberAUR_MessageGSU_NotificationT()
        {
            //arr
            Console.WriteLine($"ThreadCGUD_MemberAUR_MessageGSU_NotificationT Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUserIdentifier user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user2, string token2) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user3, string token3) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user4, string token4) = CreateUserAndToken(communicationIdentityClient);

            var topic = "Thread sync from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2),
                new ChatThreadMember(user3)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            #region Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            //@@ChatThreadClient chatThreadClient1 = chatClient.CreateChatThread("Thread topic", members);
            // Alternatively, if you have created a chat thread before and you have its threadId, you can create a ChatThreadClient instance using:
            //@@ChatThreadClient chatThreadClient2 = chatClient.GetChatThreadClient("threadId");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            ChatThreadClient chatThreadClient = CreateInstrumentedChatThreadClient(chatClient, topic, members);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = CreateInstrumentedChatThreadClient(chatClient, topic, members);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            string updatedTopic = "Launch meeting";
            #region Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread
            chatThreadClient.UpdateThread(topic: "Launch meeting");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThread
            ChatThread chatThread = chatClient.GetChatThread(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThread

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThreadsInfo
            Pageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfo();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetChatThreadsInfo
            var threadsCount = threads.Count();

            string messageContent = "Let's meet at 11am";
            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("Let's meet at 11am");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            var messageContent2 = "Content for message 2";
            SendChatMessageResult sendChatMessageResult2 = chatThreadClient2.SendMessage(messageContent2, ChatMessagePriority.High, displayNameMessage);
            var messageContent3 = "Content for message 3";
            SendChatMessageResult sendChatMessageResult3 = chatThreadClient3.SendMessage(messageContent3, ChatMessagePriority.High, displayNameMessage);
            var messageContent4 = "Content for message 4";
            SendChatMessageResult sendChatMessageResult4 = chatThreadClient3.SendMessage(messageContent4, ChatMessagePriority.High, displayNameMessage);
            var messageContent5 = "Content for message 5";
            SendChatMessageResult sendChatMessageResult5 = chatThreadClient3.SendMessage(messageContent5, ChatMessagePriority.High, displayNameMessage);
            var messageContent6 = "Content for message 6";
            SendChatMessageResult sendChatMessageResult6 = chatThreadClient3.SendMessage(messageContent6, ChatMessagePriority.High, displayNameMessage);

            var messageId = sendChatMessageResult.Id;
            var messageId2 = sendChatMessageResult2.Id;
            var messageId3 = sendChatMessageResult3.Id;
            var messageId4 = sendChatMessageResult4.Id;
            var messageId5 = sendChatMessageResult5.Id;
            var messageId6 = sendChatMessageResult6.Id;

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage
            ChatMessage message = chatThreadClient.GetMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage
            ChatMessage message2 = chatThreadClient2.GetMessage(messageId2);
            ChatMessage message3 = chatThreadClient3.GetMessage(messageId3);
            ChatMessage message4 = chatThreadClient3.GetMessage(messageId4);
            ChatMessage message5 = chatThreadClient3.GetMessage(messageId5);
            ChatMessage message6 = chatThreadClient3.GetMessage(messageId6);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            Pageable<ChatMessage> messages2 = chatThreadClient2.GetMessages();
            var getMessagesCount = messages.Count();
            var getMessagesCount2 = messages2.Count();

            # region Pagination assertions
            Pageable<ChatMessage> messagesPaginationTest = chatThreadClient.GetMessages();
            string? continuationToken = null;
            var expectedPageSize = 2;
            var messagesCounterTotal = 0;
            var messagesCounter = 0;
            foreach (Page<ChatMessage> messagesPage in messagesPaginationTest.AsPages(continuationToken, 2))
            {
                messagesCounter = 0;
                foreach (ChatMessage messagePage in messagesPage.Values)
                {
                    messagesCounterTotal++;
                    messagesCounter++;
                }
                continuationToken = messagesPage.ContinuationToken;
                //Last request does not return items
                if (messagesPage.Values.Count == 0)
                {
                    Assert.IsNull(continuationToken);
                }
                else
                {
                    Assert.AreEqual(expectedPageSize, messagesCounter);
                }
            }
            Assert.AreEqual(8, messagesCounterTotal);
            #endregion

            string updatedMessageContent = "Instead of 11am, let's meet at 2pm";
            #region Snippet:Azure_Communication_Chat_Tests_E2E_UpdateMessage
            chatThreadClient.UpdateMessage(messageId, content: "Instead of 11am, let's meet at 2pm");
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

            var newMember = new ChatThreadMember(user4);
            #region Snippet:Azure_Communication_Chat_Tests_E2E_AddMembers
            chatThreadClient.AddMembers(members: new[] { newMember });
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_AddMembers
            Pageable<ChatThreadMember> chatThreadMembersAfterOneAdded = chatThreadClient.GetMembers();
            var chatThreadMembersAfterOneAddedCount = chatThreadMembersAfterOneAdded.Count();

            CommunicationUserIdentifier memberToBeRemoved = user4; //Better name for the snippet
            #region Snippet:Azure_Communication_Chat_Tests_E2E_RemoveMember
            chatThreadClient.RemoveMember(user: memberToBeRemoved);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_RemoveMember
            Pageable<ChatThreadMember> chatThreadMembersAfterOneDeleted = chatThreadClient.GetMembers();
            var chatThreadMembersAfterOneDeletedCount = chatThreadMembersAfterOneDeleted.Count();

            Response typingNotificationResponse = chatThreadClient.SendTypingNotification();
            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification
            chatThreadClient.SendTypingNotification();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification

            #region Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread
            chatClient.DeleteChatThread(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatThread.Members.Count);
            Assert.AreEqual(messageContent, message.Content);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.AreEqual(ChatMessagePriority.Normal, message.Priority);

            Assert.AreEqual(messageContent2, message2.Content);
            Assert.AreEqual(displayNameMessage, message2.SenderDisplayName);
            Assert.AreEqual(messageContent3, message3.Content);
            Assert.AreEqual(messageContent4, message4.Content);
            Assert.AreEqual(messageContent5, message5.Content);
            Assert.AreEqual(messageContent6, message6.Content);

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCount); //Including all types : 5 text message, 3 control messages
            Assert.AreEqual(3, getMessagesCount2); //Including all types : 1 text message, 2 control messages

            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(3, chatThreadMembersCount);
            Assert.AreEqual(4, chatThreadMembersAfterOneAddedCount);
            Assert.AreEqual(3, chatThreadMembersAfterOneDeletedCount);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationResponse.Status);
        }

        [SyncOnly]
        [Test]
        [PlaybackOnly("Message and ReadReceipt storage uses eventual consistency. Tests to get readreceipts requires delays")]
        public void ReadReceiptGS()
        {
            //arr
            Console.WriteLine($"ReadReceiptGS Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUserIdentifier user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user2, string token2) = CreateUserAndToken(communicationIdentityClient);

            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            ChatThreadClient chatThreadClient = CreateInstrumentedChatThreadClient(chatClient, "Thread topic - ReadReceipts Test", members);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient2, threadId);

            SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("This is message 1 content");
            SendChatMessageResult sendChatMessageResult2 = chatThreadClient2.SendMessage("This is message 2 content");
            var messageId2 = sendChatMessageResult.Id;
            var messageId = sendChatMessageResult2.Id;

            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient.SendReadReceipt(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient2.SendReadReceipt(messageId2);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            Pageable<ReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            Pageable<ReadReceipt> readReceipts2 = chatThreadClient2.GetReadReceipts();
            var readReceiptsCount = readReceipts.Count();
            var readReceiptsCount2 = readReceipts2.Count();

            chatClient.DeleteChatThread(threadId);

            //assert
            Assert.AreEqual(2, readReceiptsCount);
            Assert.AreEqual(2, readReceiptsCount2);
        }

        /// <summary>
        /// Thread      : Create, Get, Update, Delete
        /// Member      : Add, Update, Remove
        /// Message     : Get, Send, update
        /// Notification: Typing
        /// </summary>
        [AsyncOnly]
        [Test]
        public async Task ThreadCGUD_MemberAUR_MessageGSU_NotificationT_Async()
        {
            //arr
            Console.WriteLine($"ThreadCGUD_MemberAUR_MessageGSU_NotificationT_Async Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUserIdentifier user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user3, string token3) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user4, string token4) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var topic = "Thread async from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2),
                new ChatThreadMember(user3)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            ChatThreadClient chatThreadClient = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, members);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, members);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            var updatedTopic = "Updated topic - C# sdk";
            await chatThreadClient.UpdateThreadAsync(updatedTopic);

            ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);

            AsyncPageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfoAsync();
            var threadsCount = threads.ToEnumerableAsync().Result.Count;

            var messageContent = "Content for message 1";
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(messageContent, ChatMessagePriority.High, displayNameMessage);
            var messageContent2 = "Content for message 2";
            SendChatMessageResult sendChatMessageResult2 = await chatThreadClient2.SendMessageAsync(messageContent2, ChatMessagePriority.High, displayNameMessage);
            var messageContent3 = "Content for message 3";
            SendChatMessageResult sendChatMessageResult3 = await chatThreadClient3.SendMessageAsync(messageContent3, ChatMessagePriority.High, displayNameMessage);
            var messageContent4 = "Content for message 4";
            SendChatMessageResult sendChatMessageResult4 = await chatThreadClient3.SendMessageAsync(messageContent4, ChatMessagePriority.High, displayNameMessage);
            var messageContent5 = "Content for message 5";
            SendChatMessageResult sendChatMessageResult5 = await chatThreadClient3.SendMessageAsync(messageContent5, ChatMessagePriority.High, displayNameMessage);
            var messageContent6 = "Content for message 6";
            SendChatMessageResult sendChatMessageResult6 = await chatThreadClient3.SendMessageAsync(messageContent6, ChatMessagePriority.High, displayNameMessage);

            var messageId = sendChatMessageResult.Id;
            var messageId2 = sendChatMessageResult2.Id;
            var messageId3 = sendChatMessageResult3.Id;
            var messageId4 = sendChatMessageResult4.Id;
            var messageId5 = sendChatMessageResult5.Id;
            var messageId6 = sendChatMessageResult6.Id;

            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);
            ChatMessage message2 = await chatThreadClient2.GetMessageAsync(messageId2);
            ChatMessage message3 = await chatThreadClient3.GetMessageAsync(messageId3);
            ChatMessage message4 = await chatThreadClient3.GetMessageAsync(messageId4);
            ChatMessage message5 = await chatThreadClient3.GetMessageAsync(messageId5);
            ChatMessage message6 = await chatThreadClient3.GetMessageAsync(messageId6);

            AsyncPageable<ChatMessage> messages = chatThreadClient.GetMessagesAsync();
            AsyncPageable<ChatMessage> messages2 = chatThreadClient2.GetMessagesAsync();
            var getMessagesCount = messages.ToEnumerableAsync().Result.Count;
            var getMessagesCount2 = messages2.ToEnumerableAsync().Result.Count;

            #region Pagination assertions
            AsyncPageable<ChatMessage> messagesPaginationTest = chatThreadClient.GetMessagesAsync();
            string? continuationToken = null;
            var expectedPageSize = 2;
            var messagesCounterTotal = 0;
            var messagesCounter = 0;
            await foreach (Page<ChatMessage> messagesPage in messagesPaginationTest.AsPages(continuationToken, 2))
            {
                messagesCounter = 0;
                foreach (ChatMessage messagePage in messagesPage.Values)
                {
                    messagesCounterTotal++;
                    messagesCounter++;
                }
                continuationToken = messagesPage.ContinuationToken;
                //Last request does not return items
                if (messagesPage.Values.Count == 0)
                {
                    Assert.IsNull(continuationToken);
                }
                else
                {
                    Assert.AreEqual(expectedPageSize, messagesCounter);
                }
            }
            Assert.AreEqual(8, messagesCounterTotal);
            #endregion

            var updatedMessageContent = "This is message 1 content updated";
            await chatThreadClient.UpdateMessageAsync(messageId, updatedMessageContent);
            Response<ChatMessage> actualUpdateMessage = await chatThreadClient.GetMessageAsync(messageId);

            await chatThreadClient.DeleteMessageAsync(messageId);
            List<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessagesAsync().ToEnumerableAsync().Result;
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.First(x => x.Id == messageId);

            AsyncPageable<ChatThreadMember> chatThreadMembers = chatThreadClient.GetMembersAsync();
            var chatThreadMembersCount = chatThreadMembers.ToEnumerableAsync().Result.Count;

            var newMember = new ChatThreadMember(user4);
            await chatThreadClient.AddMembersAsync(members: new[] { newMember });
            AsyncPageable<ChatThreadMember> chatThreadMembersAfterOneAdded = chatThreadClient.GetMembersAsync();
            var chatThreadMembersAfterOneAddedCount = chatThreadMembersAfterOneAdded.ToEnumerableAsync().Result.Count;

            CommunicationUserIdentifier memberToBeRemoved = user4;
            await chatThreadClient.RemoveMemberAsync(user: memberToBeRemoved);
            AsyncPageable<ChatThreadMember> chatThreadMembersAfterOneDeleted = chatThreadClient.GetMembersAsync();
            var chatThreadMembersAfterOneDeletedCount = chatThreadMembersAfterOneDeleted.ToEnumerableAsync().Result.Count;

            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();
            await chatThreadClient.SendTypingNotificationAsync();

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatThread.Members.Count);
            Assert.AreEqual(messageContent, message.Content);
            Assert.AreEqual(displayNameMessage, message.SenderDisplayName);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.AreEqual(ChatMessagePriority.High, message.Priority);

            Assert.AreEqual(messageContent2, message2.Content);
            Assert.AreEqual(messageContent3, message3.Content);
            Assert.AreEqual(messageContent4, message4.Content);
            Assert.AreEqual(messageContent5, message5.Content);
            Assert.AreEqual(messageContent6, message6.Content);

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCount); //Including all types : 5 text message, 3 control messages
            Assert.AreEqual(3, getMessagesCount2); //Including all types : 1 text message, 2 control messages

            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(3, chatThreadMembersCount);
            Assert.AreEqual(4, chatThreadMembersAfterOneAddedCount);
            Assert.AreEqual(3, chatThreadMembersAfterOneDeletedCount);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationResponse.Status);
        }

        [AsyncOnly]
        [Test]
        [PlaybackOnly("Message and ReadReceipt storage uses eventual consistency. Tests to get readreceipts requires delays")]
        public async Task ReadReceiptGSAsync()
        {
            //arr
            Console.WriteLine($"ReadReceiptGSAsync Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUserIdentifier user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var members = new List<ChatThreadMember>
            {
                new ChatThreadMember(user1),
                new ChatThreadMember(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            ChatThreadClient chatThreadClient = await CreateInstrumentedChatThreadClientAsync(chatClient, "Thread topic - ReadReceipts Async Test", members);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient2, threadId);

            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync("This is message 1 content");
            SendChatMessageResult sendChatMessageResult2 = await chatThreadClient2.SendMessageAsync("This is message 2 content");
            var messageId2 = sendChatMessageResult.Id;
            var messageId = sendChatMessageResult2.Id;

            await chatThreadClient.SendReadReceiptAsync(messageId);
            await chatThreadClient2.SendReadReceiptAsync(messageId2);

            AsyncPageable<ReadReceipt> readReceipts = chatThreadClient.GetReadReceiptsAsync();
            AsyncPageable<ReadReceipt> readReceipts2 = chatThreadClient2.GetReadReceiptsAsync();
            var readReceiptsCount = readReceipts.ToEnumerableAsync().Result.Count;
            var readReceiptsCount2 = readReceipts2.ToEnumerableAsync().Result.Count;

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(2, readReceiptsCount);
            Assert.AreEqual(2, readReceiptsCount2);
        }

        private (CommunicationUserIdentifier user, string token) CreateUserAndToken(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> threadMember = communicationIdentityClient.CreateUser();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseThreadMember = communicationIdentityClient.IssueToken(threadMember.Value, scopes);

            return (tokenResponseThreadMember.Value.User, tokenResponseThreadMember.Value.Token);
        }

        private async Task<(CommunicationUserIdentifier user, string token)> CreateUserAndTokenAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> threadMember = await communicationIdentityClient.CreateUserAsync();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseThreadMember = await communicationIdentityClient.IssueTokenAsync(threadMember.Value, scopes);

            return (tokenResponseThreadMember.Value.User, tokenResponseThreadMember.Value.Token);
        }
    }
}
