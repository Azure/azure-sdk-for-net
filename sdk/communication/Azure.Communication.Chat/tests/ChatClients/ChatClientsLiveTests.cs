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

namespace Azure.Communication.Chat.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="ChatClient"/> and <see cref="ChatThreadClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class ChatClientsLiveTests : ChatLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationIdentityClient"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public ChatClientsLiveTests(bool isAsync) : base(isAsync)
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
            (CommunicationUserIdentifier user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user2, _) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user3, string token3) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user4, _) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUserIdentifier user5, _) = CreateUserAndToken(communicationIdentityClient);

            string repeatabilityRequestId1 = "contoso-F0A747F1-6245-4307-8267-B974340677D2";
            string repeatabilityRequestId2 = "contoso-A0A747F1-6245-4307-8267-B974340677DA";

            var topic = "Thread sync from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var participants = new[]
            {
                new ChatParticipant(user1) { DisplayName = "user1" },
                new ChatParticipant(user2) { DisplayName = "user2" },
                new ChatParticipant(user3) { DisplayName = "user3" }
            };

            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread(topic, participants, repeatabilityRequestId1);
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult.ChatThread.Id);
            var threadId = chatThreadClient.Id;

            CreateChatThreadResult createChatThreadResult2 = chatClient.CreateChatThread(topic, participants, repeatabilityRequestId2);
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult2.ChatThread.Id);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            Pageable<ChatParticipant> chatParticipantsOnCreation = chatThreadClient.GetParticipants();
            var chatParticipantsOnCreationCount = chatParticipantsOnCreation.Count();

            string updatedTopic = "Launch meeting";
            chatThreadClient.UpdateTopic(topic: "Launch meeting");

            ChatThread chatThread = chatClient.GetChatThread(threadId);

            string messageContent = "Let's meet at 11am";
            string messageId = chatThreadClient.SendMessage("Let's meet at 11am");
            string messageContent2 = "Content for message 2";
            string messageId2 = chatThreadClient2.SendMessage(messageContent2, ChatMessageType.Text, displayNameMessage);
            string messageContent3 = "Content for message 3";
            string messageId3 = chatThreadClient3.SendMessage(messageContent3, ChatMessageType.Html, displayNameMessage);
            string messageContent4 = "Content for message 4";
            string messageId4 = chatThreadClient3.SendMessage(messageContent4, ChatMessageType.Text, displayNameMessage);
            string messageContent5 = "Content for message 5";
            string messageId5 = chatThreadClient3.SendMessage(messageContent5, ChatMessageType.Html, displayNameMessage);
            string messageContent6 = "Content for message 6";
            string messageId6 = chatThreadClient3.SendMessage(messageContent6, ChatMessageType.Text, displayNameMessage);

            ChatMessage message = chatThreadClient.GetMessage(messageId);
            ChatMessage message2 = chatThreadClient2.GetMessage(messageId2);
            ChatMessage message3 = chatThreadClient3.GetMessage(messageId3);
            ChatMessage message4 = chatThreadClient3.GetMessage(messageId4);
            ChatMessage message5 = chatThreadClient3.GetMessage(messageId5);
            ChatMessage message6 = chatThreadClient3.GetMessage(messageId6);

            Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
            Pageable<ChatMessage> messages2 = chatThreadClient2.GetMessages();
            var getMessagesCount = messages.Count();
            var getMessagesCount2 = messages2.Count();

            Pageable<ChatMessage> pageableMessages = chatThreadClient.GetMessages();
            PageableTester<ChatMessage>.AssertPagination(enumerableResource:pageableMessages, expectedPageSize: 2, expectedTotalResources : 8);

            string updatedMessageContent = "Instead of 11am, let's meet at 2pm";
            chatThreadClient.UpdateMessage(messageId, content: "Instead of 11am, let's meet at 2pm");
            Response<ChatMessage> actualUpdateMessage = chatThreadClient.GetMessage(messageId);

            chatThreadClient.DeleteMessage(messageId);
            Pageable<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessages();
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.First(x => x.Id == messageId);

            Pageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipants();
            var chatParticipantsCount = chatParticipants.Count();

            var newParticipant = new ChatParticipant(user4) { DisplayName = "user4" };
            var newParticipant2 = new ChatParticipant(user5) { DisplayName = "user5" };
            chatThreadClient.AddParticipants(participants: new[] { newParticipant });
            AddChatParticipantsResult addChatParticipantsResult = chatThreadClient.AddParticipant(newParticipant2);

            Pageable<ChatParticipant> chatParticipantsAfterTwoAdded = chatThreadClient.GetParticipants();
            PageableTester<ChatParticipant>.AssertPagination(enumerableResource: chatParticipantsAfterTwoAdded, expectedPageSize: 2, expectedTotalResources: 5);
            var chatParticipantsAfterTwoAddedCount = chatParticipantsAfterTwoAdded.Count();

            Pageable<ChatMessage> messagesAfterParticipantsAdded = chatThreadClient.GetMessages();
            ChatMessage participantAddedMessage = messagesAfterParticipantsAdded.First(x => x.Type == ChatMessageType.ParticipantAdded);

            CommunicationUserIdentifier participantToBeRemoved = user4;
            chatThreadClient.RemoveParticipant(identifier: participantToBeRemoved);
            Pageable<ChatParticipant> chatParticipantAfterOneDeleted = chatThreadClient.GetParticipants();
            var chatParticipantAfterOneDeletedCount = chatParticipantAfterOneDeleted.Count();

            Pageable<ChatMessage> messagesAfterParticipantRemoved = chatThreadClient.GetMessages();
            ChatMessage participantRemovedMessage = messagesAfterParticipantRemoved.First(x => x.Type == ChatMessageType.ParticipantRemoved);

            Response typingNotificationResponse = chatThreadClient.SendTypingNotification();
            chatThreadClient.SendTypingNotification();

            Pageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfo();
            var threadsCount = threads.Count();

            chatClient.DeleteChatThread(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatParticipantsOnCreationCount);
            Assert.AreEqual(messageContent, message.Content.Message);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content.Message);
            Assert.AreEqual(ChatMessageType.Text, message.Type);

            Assert.AreEqual(messageContent2, message2.Content.Message);
            Assert.AreEqual(displayNameMessage, message2.SenderDisplayName);
            Assert.AreEqual(messageContent3, message3.Content.Message);
            Assert.AreEqual(messageContent4, message4.Content.Message);
            Assert.AreEqual(messageContent5, message5.Content.Message);
            Assert.AreEqual(messageContent6, message6.Content.Message);

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCount); //Including all types : 5 text message, 3 control messages
            Assert.AreEqual(3, getMessagesCount2); //Including all types : 1 text message, 2 control messages

            Assert.AreEqual(1, participantAddedMessage.Content.Participants.Count);
            Assert.AreEqual(user5.Id, CommunicationIdentifierSerializer.Serialize(participantAddedMessage.Content.Participants[0].User).CommunicationUser.Id);
            Assert.AreEqual("user5", participantAddedMessage.Content.Participants[0].DisplayName);

            Assert.AreEqual(1, participantRemovedMessage.Content.Participants.Count);
            Assert.AreEqual(user4.Id, CommunicationIdentifierSerializer.Serialize(participantRemovedMessage.Content.Participants[0].User).CommunicationUser.Id);
            Assert.AreEqual("user4", participantRemovedMessage.Content.Participants[0].DisplayName);

            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(3, chatParticipantsCount);
            Assert.AreEqual(5, chatParticipantsAfterTwoAddedCount);
            Assert.AreEqual(4, chatParticipantAfterOneDeletedCount);
            Assert.IsNull(addChatParticipantsResult.Errors);
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

            string repeatabilityRequestId1 = "contoso-B0A747F1-6245-4307-8267-B974340677DB";

            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            //act
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread("Thread topic - ReadReceipts Test", participants, repeatabilityRequestId1);
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult.ChatThread.Id);
            var threadId = chatThreadClient.Id;
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient2, threadId);

            var messageId2 = chatThreadClient.SendMessage("This is message 1 content");
            var messageId = chatThreadClient2.SendMessage("This is message 2 content");

            chatThreadClient.SendReadReceipt(messageId);
            chatThreadClient2.SendReadReceipt(messageId2);

            Pageable<ChatMessageReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
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
            (CommunicationUserIdentifier user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user2, _) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user3, string token3) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user4, _) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUserIdentifier user5, _) = await CreateUserAndTokenAsync(communicationIdentityClient);

            string repeatabilityRequestId1 = "contoso-C0A747F1-6245-4307-8267-B974340677DC";
            string repeatabilityRequestId2 = "contoso-D0A747F1-6245-4307-8267-B974340677DD";

            var topic = "Thread async from C# sdk";
            var displayNameMessage = "DisplayName sender message 1";
            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1) { DisplayName = "user1" },
                new ChatParticipant(user2) { DisplayName = "user2" },
                new ChatParticipant(user3) { DisplayName = "user3" }
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            //act
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic, participants, repeatabilityRequestId1);
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult.ChatThread.Id);
            var threadId = chatThreadClient.Id;
            CreateChatThreadResult createChatThreadResult2 = await chatClient.CreateChatThreadAsync(topic, participants, repeatabilityRequestId2);
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult2.ChatThread.Id);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            AsyncPageable<ChatParticipant> chatParticipantsOnCreation = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsOnCreationCount = chatParticipantsOnCreation.ToEnumerableAsync().Result.Count;

            var updatedTopic = "Updated topic - C# sdk";
            await chatThreadClient.UpdateTopicAsync(updatedTopic);

            ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);

            string messageContent = "Content for message 1";
            string messageId = await chatThreadClient.SendMessageAsync(messageContent, ChatMessageType.Text, displayNameMessage);
            string messageContent2 = "Content for message 2";
            string messageId2 = await chatThreadClient2.SendMessageAsync(messageContent2, ChatMessageType.Html, displayNameMessage);
            string messageContent3 = "Content for message 3";
            string messageId3 = await chatThreadClient3.SendMessageAsync(messageContent3, ChatMessageType.Text, displayNameMessage);
            string messageContent4 = "Content for message 4";
            string messageId4 = await chatThreadClient3.SendMessageAsync(messageContent4, ChatMessageType.Html, displayNameMessage);
            string messageContent5 = "Content for message 5";
            string messageId5 = await chatThreadClient3.SendMessageAsync(messageContent5, ChatMessageType.Text, displayNameMessage);
            string messageContent6 = "Content for message 6";
            string messageId6 = await chatThreadClient3.SendMessageAsync(messageContent6, ChatMessageType.Html, displayNameMessage);

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

            #region Messages Pagination assertions
            AsyncPageable<ChatMessage> messagesPaginationTest = chatThreadClient.GetMessagesAsync();
            await PageableTester<ChatMessage>.AssertPaginationAsync(enumerableResource: messagesPaginationTest, expectedPageSize: 2, expectedTotalResources: 8);
            #endregion

            var updatedMessageContent = "This is message 1 content updated";
            await chatThreadClient.UpdateMessageAsync(messageId, updatedMessageContent);
            Response<ChatMessage> actualUpdateMessage = await chatThreadClient.GetMessageAsync(messageId);

            await chatThreadClient.DeleteMessageAsync(messageId);
            List<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessagesAsync().ToEnumerableAsync().Result;
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.First(x => x.Id == messageId);

            #region Participants Pagination assertions
            AsyncPageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsCount = chatParticipants.ToEnumerableAsync().Result.Count;
            #endregion

            var newParticipant = new ChatParticipant(user4) { DisplayName = "user4" };
            var newParticipant2 = new ChatParticipant(user5) { DisplayName = "user5" };
            AddChatParticipantsResult addChatParticipantsResult = await chatThreadClient.AddParticipantsAsync(participants: new[] { newParticipant });
            AddChatParticipantsResult addChatParticipantsResult2 = await chatThreadClient.AddParticipantAsync(newParticipant2);

            AsyncPageable<ChatParticipant> chatParticipantsAfterTwoOneAdded = chatThreadClient.GetParticipantsAsync();
            await PageableTester<ChatParticipant>.AssertPaginationAsync(enumerableResource: chatParticipantsAfterTwoOneAdded, expectedPageSize: 2, expectedTotalResources: 5);
            var chatParticipantsAfterTwoOneAddedCount = chatParticipantsAfterTwoOneAdded.ToEnumerableAsync().Result.Count;

            List<ChatMessage> messagesAfterParticipantsAdded = chatThreadClient.GetMessagesAsync().ToEnumerableAsync().Result;
            ChatMessage participantAddedMessage = messagesAfterParticipantsAdded.First(x => x.Type == ChatMessageType.ParticipantAdded);

            CommunicationUserIdentifier participantToBeRemoved = user4;
            await chatThreadClient.RemoveParticipantAsync(identifier: participantToBeRemoved);
            AsyncPageable<ChatParticipant> chatParticipantAfterOneDeleted = chatThreadClient.GetParticipantsAsync();
            var chatParticipantAfterOneDeletedCount = chatParticipantAfterOneDeleted.ToEnumerableAsync().Result.Count;

            List<ChatMessage> messagesAfterParticipantRemoved = chatThreadClient.GetMessagesAsync().ToEnumerableAsync().Result;
            ChatMessage participantRemovedMessage = messagesAfterParticipantRemoved.First(x => x.Type == ChatMessageType.ParticipantRemoved);

            ChatMessage participantRemovedMessage2 = await chatThreadClient.GetMessageAsync(participantRemovedMessage.Id);

            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();
            await chatThreadClient.SendTypingNotificationAsync();

            AsyncPageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfoAsync();
            var threadsCount = threads.ToEnumerableAsync().Result.Count;

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatParticipantsOnCreationCount);
            Assert.AreEqual(messageContent, message.Content.Message);
            Assert.AreEqual(displayNameMessage, message.SenderDisplayName);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content.Message);
            Assert.AreEqual(ChatMessageType.Text, message.Type);

            Assert.AreEqual(messageContent2, message2.Content.Message);
            Assert.AreEqual(messageContent3, message3.Content.Message);
            Assert.AreEqual(messageContent4, message4.Content.Message);
            Assert.AreEqual(messageContent5, message5.Content.Message);
            Assert.AreEqual(messageContent6, message6.Content.Message);

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCount); //Including all types : 5 text message, 3 control messages
            Assert.AreEqual(3, getMessagesCount2); //Including all types : 1 text message, 2 control messages

            Assert.AreEqual(1, participantAddedMessage.Content.Participants.Count);
            Assert.AreEqual(user5.Id, CommunicationIdentifierSerializer.Serialize(participantAddedMessage.Content.Participants[0].User).CommunicationUser.Id);
            Assert.AreEqual("user5", participantAddedMessage.Content.Participants[0].DisplayName);

            Assert.AreEqual(1, participantRemovedMessage.Content.Participants.Count);
            Assert.AreEqual(user4.Id, CommunicationIdentifierSerializer.Serialize(participantRemovedMessage.Content.Participants[0].User).CommunicationUser.Id);
            Assert.AreEqual("user4", participantRemovedMessage.Content.Participants[0].DisplayName);

            Assert.IsTrue(deletedChatMessage.DeletedOn.HasValue);
            Assert.AreEqual(3, chatParticipantsCount);
            Assert.AreEqual(5, chatParticipantsAfterTwoOneAddedCount);
            Assert.AreEqual(4, chatParticipantAfterOneDeletedCount);
            Assert.IsNull(addChatParticipantsResult.Errors);
            Assert.IsNull(addChatParticipantsResult2.Errors);
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

            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1),
                new ChatParticipant(user2)
            };
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient2 = CreateInstrumentedChatClient(token2);

            string repeatabilityRequestId1 = "contoso-E0A747F1-6245-4307-8267-B974340677DE";

            //act
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync("Thread topic - ReadReceipts Async Test", participants, repeatabilityRequestId1);
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult.ChatThread.Id);
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

        #region Support functions
        private (CommunicationUserIdentifier user, string token) CreateUserAndToken(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> user = communicationIdentityClient.CreateUser();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<AccessToken> tokenResponseUser = communicationIdentityClient.GetToken(user.Value, scopes);

            return (user, tokenResponseUser.Value.Token);
        }

        private async Task<(CommunicationUserIdentifier user, string token)> CreateUserAndTokenAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> user = await communicationIdentityClient.CreateUserAsync();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<AccessToken> tokenResponseUser = await communicationIdentityClient.GetTokenAsync(user.Value, scopes);

            return (user, tokenResponseUser.Value.Token);
        }

        private static class PageableTester<T> where T: notnull
        {
            public static void AssertPagination(Pageable<T> enumerableResource, int expectedPageSize, int expectedTotalResources)
            {
                string? continuationToken = null;
                int expectedRoundTrips = (expectedTotalResources / expectedPageSize) + 1;
                int actualPageSize, actualTotalResources = 0, actualRoundTrips = 0;
                foreach (Page<T> page in enumerableResource.AsPages(continuationToken, expectedPageSize))
                {
                    actualRoundTrips++;
                    actualPageSize = 0;
                    foreach (T resource in page.Values)
                    {
                        actualPageSize++;
                        actualTotalResources++;
                    }
                    continuationToken = page.ContinuationToken;
                    Assert.GreaterOrEqual(expectedPageSize, actualPageSize);
                }
                Assert.IsNull(continuationToken);
                Assert.AreEqual(expectedTotalResources, actualTotalResources);
                Assert.AreEqual(expectedRoundTrips, actualRoundTrips);
            }

            public static async Task AssertPaginationAsync(AsyncPageable<T> enumerableResource, int expectedPageSize, int expectedTotalResources)
            {
                string? continuationToken = null;
                int expectedRoundTrips = (expectedTotalResources / expectedPageSize) + 1;
                int actualPageSize, actualTotalResources = 0, actualRoundTrips = 0;
                await foreach (Page<T> page in enumerableResource.AsPages(continuationToken, expectedPageSize))
                {
                    actualRoundTrips++;
                    actualPageSize = 0;
                    foreach (T resource in page.Values)
                    {
                        actualPageSize++;
                        actualTotalResources++;
                    }
                    continuationToken = page.ContinuationToken;
                    Assert.GreaterOrEqual(expectedPageSize, actualPageSize);
                }
                Assert.IsNull(continuationToken);
                Assert.AreEqual(expectedTotalResources, actualTotalResources);
                Assert.AreEqual(expectedRoundTrips, actualRoundTrips);
            }
        }
        #endregion
    }
}
