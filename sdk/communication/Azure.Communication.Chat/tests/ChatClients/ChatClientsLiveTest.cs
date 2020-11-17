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
        /// Thread: Create, Get, Update, Delete
        /// Participant: Add, Update, Remove
        /// Message: Get, Send, update
        /// Notification: Typing
        /// </summary>
        [SyncOnly]
        [Test]
        public void ThreadCGUD_ParticipantAUR_MessageGSU_NotificationT()
        {
            //arr
            Console.WriteLine($"ThreadCGUD_ParticipantAUR_MessageGSU_NotificationT Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUser user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user2, string token2) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user3, string token3) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user4, _) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user5, _) = CreateUserAndToken(communicationIdentityClient);

            var topic = "Thread sync from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var participants = new[]
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2),
                new ChatParticipant(user3)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            #region Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            //@@ChatThreadClient chatThreadClient1 = chatClient.CreateChatThread("Thread topic", participants);
            // Alternatively, if you have created a chat thread before and you have its threadId, you can create a ChatThreadClient instance using:
            //@@ChatThreadClient chatThreadClient2 = chatClient.GetChatThreadClient("threadId");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_InitializeChatThreadClient
            ChatThreadClient chatThreadClient = CreateInstrumentedChatThreadClient(chatClient, topic, participants);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = CreateInstrumentedChatThreadClient(chatClient, topic, participants);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            string updatedTopic = "Launch meeting";
            #region Snippet:Azure_Communication_Chat_Tests_E2E_UpdateThread
            chatThreadClient.UpdateTopic(topic: "Launch meeting");
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
            string messageId = chatThreadClient.SendMessage("Let's meet at 11am");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            string messageContent2 = "Content for message 2";
            string messageId2 = chatThreadClient2.SendMessage(messageContent2, ChatMessagePriority.High, displayNameMessage);
            string messageContent3 = "Content for message 3";
            string messageId3 = chatThreadClient3.SendMessage(messageContent3, ChatMessagePriority.High, displayNameMessage);
            string messageContent4 = "Content for message 4";
            string messageId4 = chatThreadClient3.SendMessage(messageContent4, ChatMessagePriority.High, displayNameMessage);
            string messageContent5 = "Content for message 5";
            string messageId5 = chatThreadClient3.SendMessage(messageContent5, ChatMessagePriority.High, displayNameMessage);
            string messageContent6 = "Content for message 6";
            string messageId6 = chatThreadClient3.SendMessage(messageContent6, ChatMessagePriority.High, displayNameMessage);

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
            foreach (Page<ChatMessage> messagesPage in messagesPaginationTest.AsPages(continuationToken,2))
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

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetParticipants
            Pageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipants();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetParticipants
            var chatParticipantsCount = chatParticipants.Count();

            var newParticipant = new ChatParticipant(user4);
            var newParticipant2 = new ChatParticipant(user5);
            #region Snippet:Azure_Communication_Chat_Tests_E2E_AddParticipants
            chatThreadClient.AddParticipants(participants: new[] { newParticipant });
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_AddParticipants
            chatThreadClient.AddParticipant(newParticipant2);

            Pageable<ChatParticipant> chatParticipantsAfterTwoAdded = chatThreadClient.GetParticipants();
            var chatParticipantsAfterTwoAddedCount = chatParticipantsAfterTwoAdded.Count();

            CommunicationUser participantToBeRemoved = user4;
            #region Snippet:Azure_Communication_Chat_Tests_E2E_RemoveParticipant
            chatThreadClient.RemoveParticipant(user: participantToBeRemoved);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_RemoveParticipant
            Pageable<ChatParticipant> chatParticipantAfterOneDeleted = chatThreadClient.GetParticipants();
            var chatParticipantAfterOneDeletedCount = chatParticipantAfterOneDeleted.Count();

            Response typingNotificationResponse = chatThreadClient.SendTypingNotification();
            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification
            chatThreadClient.SendTypingNotification();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendTypingNotification

            #region Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread
            chatClient.DeleteChatThread(threadId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_DeleteChatThread

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatThread.Participants.Count);
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
            Assert.AreEqual(3, chatParticipantsCount);
            Assert.AreEqual(5, chatParticipantsAfterTwoAddedCount);
            Assert.AreEqual(4, chatParticipantAfterOneDeletedCount);
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
            (CommunicationUser user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user2, string token2) = CreateUserAndToken(communicationIdentityClient);

            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            ChatThreadClient chatThreadClient = CreateInstrumentedChatThreadClient(chatClient, "Thread topic - ReadReceipts Test", participants);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient2, threadId);

            var messageId2 = chatThreadClient.SendMessage("This is message 1 content");
            var messageId = chatThreadClient2.SendMessage("This is message 2 content");

            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient.SendReadReceipt(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendReadReceipt
            chatThreadClient2.SendReadReceipt(messageId2);

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            Pageable<ChatMessageReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetReadReceipts
            Pageable<ChatMessageReadReceipt> readReceipts2 = chatThreadClient2.GetReadReceipts();
            var readReceiptsCount = readReceipts.Count();
            var readReceiptsCount2 = readReceipts2.Count();

            chatClient.DeleteChatThread(threadId);

            //assert
            Assert.AreEqual(2, readReceiptsCount);
            Assert.AreEqual(2, readReceiptsCount2);
        }

        /// <summary>
        /// Thread: Create, Get, Update, Delete
        /// Participant: Add, Update, Remove
        /// Message: Get, Send, update
        /// Notification: Typing
        /// </summary>
        [AsyncOnly]
        [Test]
        public async Task ThreadCGUD_ParticipantAUR_MessageGSU_NotificationT_Async()
        {
            //arr
            Console.WriteLine($"ThreadCGUD_ParticipantAUR_MessageGSU_NotificationT_Async Running on RecordedTestMode : {Mode}");
            CommunicationIdentityClient communicationIdentityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUser user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user3, string token3) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user4, _) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user5, _) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var topic = "Thread async from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2),
                new ChatParticipant(user3)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            ChatThreadClient chatThreadClient = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, participants);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = await CreateInstrumentedChatThreadClientAsync(chatClient, topic, participants);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            var updatedTopic = "Updated topic - C# sdk";
            await chatThreadClient.UpdateTopicAsync(updatedTopic);

            ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);

            AsyncPageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfoAsync();
            var threadsCount = threads.ToEnumerableAsync().Result.Count;

            string messageContent = "Content for message 1";
            string messageId = await chatThreadClient.SendMessageAsync(messageContent, ChatMessagePriority.High, displayNameMessage);
            string messageContent2 = "Content for message 2";
            string messageId2 = await chatThreadClient2.SendMessageAsync(messageContent2, ChatMessagePriority.High, displayNameMessage);
            string messageContent3 = "Content for message 3";
            string messageId3 = await chatThreadClient3.SendMessageAsync(messageContent3, ChatMessagePriority.High, displayNameMessage);
            string messageContent4 = "Content for message 4";
            string messageId4 = await chatThreadClient3.SendMessageAsync(messageContent4, ChatMessagePriority.High, displayNameMessage);
            string messageContent5 = "Content for message 5";
            string messageId5 = await chatThreadClient3.SendMessageAsync(messageContent5, ChatMessagePriority.High, displayNameMessage);
            string messageContent6 = "Content for message 6";
            string messageId6 = await chatThreadClient3.SendMessageAsync(messageContent6, ChatMessagePriority.High, displayNameMessage);

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

            AsyncPageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsCount = chatParticipants.ToEnumerableAsync().Result.Count;

            var newParticipant = new ChatParticipant(user4);
            var newParticipant2 = new ChatParticipant(user5);
            await chatThreadClient.AddParticipantsAsync(participants: new[] { newParticipant });
            await chatThreadClient.AddParticipantAsync(newParticipant2);
            AsyncPageable<ChatParticipant> chatParticipantsAfterTwoOneAdded = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsAfterTwoOneAddedCount = chatParticipantsAfterTwoOneAdded.ToEnumerableAsync().Result.Count;

            CommunicationUser participantToBeRemoved = user4;
            await chatThreadClient.RemoveParticipantAsync(user: participantToBeRemoved);
            AsyncPageable<ChatParticipant> chatParticipantAfterOneDeleted = chatThreadClient.GetParticipantsAsync();
            var chatParticipantAfterOneDeletedCount = chatParticipantAfterOneDeleted.ToEnumerableAsync().Result.Count;

            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();
            await chatThreadClient.SendTypingNotificationAsync();

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatThread.Participants.Count);
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
            Assert.AreEqual(3, chatParticipantsCount);
            Assert.AreEqual(5, chatParticipantsAfterTwoOneAddedCount);
            Assert.AreEqual(4, chatParticipantAfterOneDeletedCount);
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
            (CommunicationUser user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            ChatThreadClient chatThreadClient = await CreateInstrumentedChatThreadClientAsync(chatClient, "Thread topic - ReadReceipts Async Test", participants);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient2, threadId);

            string messageId2 = await chatThreadClient.SendMessageAsync("This is message 1 content");
            string messageId = await chatThreadClient2.SendMessageAsync("This is message 2 content");

            await chatThreadClient.SendReadReceiptAsync(messageId);
            await chatThreadClient2.SendReadReceiptAsync(messageId2);

            AsyncPageable<ChatMessageReadReceipt> readReceipts = chatThreadClient.GetReadReceiptsAsync();
            AsyncPageable<ChatMessageReadReceipt> readReceipts2 = chatThreadClient2.GetReadReceiptsAsync();
            var readReceiptsCount = readReceipts.ToEnumerableAsync().Result.Count;
            var readReceiptsCount2 = readReceipts2.ToEnumerableAsync().Result.Count;

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(2, readReceiptsCount);
            Assert.AreEqual(2, readReceiptsCount2);
        }

        private (CommunicationUser user, string token) CreateUserAndToken(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUser> user = communicationIdentityClient.CreateUser();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseUser = communicationIdentityClient.IssueToken(user.Value, scopes);

            return (tokenResponseUser.Value.User, tokenResponseUser.Value.Token);
        }

        private async Task<(CommunicationUser user, string token)> CreateUserAndTokenAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUser> user = await communicationIdentityClient.CreateUserAsync();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<CommunicationUserToken> tokenResponseUser = await communicationIdentityClient.IssueTokenAsync(user.Value, scopes);

            return (tokenResponseUser.Value.User, tokenResponseUser.Value.Token);
        }
    }
}
