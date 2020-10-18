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
            (CommunicationUser user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user2, string token2) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user3, string token3) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user4, string token4) = CreateUserAndToken(communicationIdentityClient);

            var messageTemplate = "Content for message {0}";
            var displayNameTemplate = "Display Name for message {0}";
            var topic = "Thread sync from C# sdk";
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

            #region Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage
            SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("Let's meet at 11am");
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_SendMessage

            var messageId = sendChatMessageResult.Id;
            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage
            ChatMessage message = chatThreadClient.GetMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessage

            var messagesMapping = new ChatMessage[6];
            messagesMapping[0] = message;
            messagesMapping[1] = ExecuteSendGetMessage(1, chatThreadClient2, messageTemplate, displayNameTemplate, ChatMessagePriority.High);
            for (int i = 2; i < 6; i++)
            {
                messagesMapping[i] = ExecuteSendGetMessage(i, chatThreadClient3, messageTemplate, displayNameTemplate, ChatMessagePriority.High);
            }

            #region Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
            #endregion Snippet:Azure_Communication_Chat_Tests_E2E_GetMessages
            Pageable<ChatMessage> messagesThread2 = chatThreadClient2.GetMessages();
            var getMessagesCountThread1 = messages.Count();
            var getMessagesCountThread2 = messagesThread2.Count();

            # region Pagination assertions
            Pageable<ChatMessage> allMessages = chatThreadClient.GetMessages();
            string? continuationToken = null;
            var expectedPageSize = 2;
            var messagesTotal = 0;
            var actualMessagesPerPage = 0;
            var sentTextMessageIndex = messagesMapping.Length;
            DateTimeOffset? previousCreatedOn = DateTimeOffset.MaxValue;
            ulong previousId = ulong.MaxValue;
            foreach (Page<ChatMessage> messagesPage in allMessages.AsPages(continuationToken, expectedPageSize))
            {
                actualMessagesPerPage = messagesPage.Values.Count;
                foreach (ChatMessage chatMessage in messagesPage.Values)
                {
                    if (chatMessage.Type == "Text")
                    {
                        sentTextMessageIndex--;
                        if (sentTextMessageIndex == 1)
                            sentTextMessageIndex--; // skip index for message on thread 2
                        Assert.AreEqual(messagesMapping[sentTextMessageIndex].Content, chatMessage.Content);
                        Assert.AreEqual(messagesMapping[sentTextMessageIndex].Id, chatMessage.Id);
                    }
                    // Make sure all message types (not just TEXT) are kept in the expected order received from the service. Equals needs to be accounted due to ms precision conversion.
                    Assert.LessOrEqual(chatMessage.CreatedOn, previousCreatedOn);

                    // Message Ids are auto-incremented / uniquely created downstream using epoc time conversions. Could be used on the client side to disambiguate order in case of identical CreatedOn timestamps
                    Assert.Less(ulong.Parse(chatMessage.Id), previousId);
                    previousCreatedOn = chatMessage.CreatedOn;
                    previousId = ulong.Parse(chatMessage.Id);
                }
                continuationToken = messagesPage.ContinuationToken;
                messagesTotal += actualMessagesPerPage;
                // Last request should not return continuation token
                if (actualMessagesPerPage == 0)
                {
                    Assert.IsNull(messagesPage.ContinuationToken);
                }
                else
                {
                    Assert.AreEqual(expectedPageSize, actualMessagesPerPage);
                }
            }
            Assert.AreEqual(8, messagesTotal);
            Assert.AreEqual(0, sentTextMessageIndex);
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

            CommunicationUser memberToBeRemoved = user4; //Better name for the snippet
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
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.AreEqual(ChatMessagePriority.Normal, messagesMapping[0].Priority);

            for (int index = 1; index < 6; index++)
            {
                Assert.AreEqual(string.Format(messageTemplate, index), messagesMapping[index].Content);
                Assert.AreEqual(string.Format(displayNameTemplate, index), messagesMapping[index].SenderDisplayName);
                Assert.AreEqual(ChatMessagePriority.High, messagesMapping[index].Priority);
            }

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCountThread1); // Including all types : 5 text messages, 3 control messages
            Assert.AreEqual(3, getMessagesCountThread2); // Including all types : 1 text message, 2 control messages

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
            (CommunicationUser user1, string token1) = CreateUserAndToken(communicationIdentityClient);
            (CommunicationUser user2, string token2) = CreateUserAndToken(communicationIdentityClient);

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
            (CommunicationUser user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user3, string token3) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user4, string token4) = await CreateUserAndTokenAsync(communicationIdentityClient);

            var messageTemplate = "Content for async message {0}";
            var displayNameTemplate = "Display Name for async  message {0}";
            var topic = "Thread async from C# sdk";
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

            var messagesMapping = new ChatMessage[6];
            messagesMapping[0] = await ExecuteSendGetMessageAsync(0, chatThreadClient, messageTemplate, displayNameTemplate, ChatMessagePriority.Normal);
            messagesMapping[1] = await ExecuteSendGetMessageAsync(1, chatThreadClient2, messageTemplate, displayNameTemplate, ChatMessagePriority.High);
            for (int i = 2; i < 6; i++)
            {
                messagesMapping[i] = await ExecuteSendGetMessageAsync(i, chatThreadClient3, messageTemplate, displayNameTemplate, ChatMessagePriority.High);
            }

            AsyncPageable<ChatMessage> messagesThread1 = chatThreadClient.GetMessagesAsync();
            AsyncPageable<ChatMessage> messagesThread2 = chatThreadClient2.GetMessagesAsync();
            var getMessagesCountThread1 = messagesThread1.ToEnumerableAsync().Result.Count;
            var getMessagesCountThread2 = messagesThread2.ToEnumerableAsync().Result.Count;

            # region Pagination assertions
            AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();
            string? continuationToken = null;
            var expectedPageSize = 2;
            var messagesTotal = 0;
            var actualMessagesPerPage = 0;
            var sentTextMessageIndex = messagesMapping.Length;
            DateTimeOffset? previousCreatedOn = DateTimeOffset.MaxValue;
            ulong previousId = ulong.MaxValue;
            await foreach (Page<ChatMessage> messagesPage in allMessages.AsPages(continuationToken, expectedPageSize))
            {
                actualMessagesPerPage = messagesPage.Values.Count;
                foreach (ChatMessage chatMessage in messagesPage.Values)
                {
                    if (chatMessage.Type == "Text")
                    {
                        sentTextMessageIndex--;
                        if (sentTextMessageIndex == 1)
                            sentTextMessageIndex--; // skip index for message on thread 2
                        Assert.AreEqual(messagesMapping[sentTextMessageIndex].Content, chatMessage.Content);
                        Assert.AreEqual(messagesMapping[sentTextMessageIndex].Id, chatMessage.Id);
                    }
                    // Make sure all message types (not just TEXT) are kept in the expected order received from the service. Equals needs to be accounted due to ms precision conversion.
                    Assert.LessOrEqual(chatMessage.CreatedOn, previousCreatedOn);

                    // Message Ids are auto-incremented / uniquely created downstream using epoc time conversions. Could be used on the client side to disambiguate order in case of identical CreatedOn timestamps
                    Assert.Less(ulong.Parse(chatMessage.Id), previousId);

                    previousCreatedOn = chatMessage.CreatedOn;
                    previousId = ulong.Parse(chatMessage.Id);
                }
                continuationToken = messagesPage.ContinuationToken;
                messagesTotal += actualMessagesPerPage;
                // Last request should not return continuation token
                if (actualMessagesPerPage == 0)
                {
                    Assert.IsNull(messagesPage.ContinuationToken);
                }
                else
                {
                    Assert.AreEqual(expectedPageSize, actualMessagesPerPage);
                }
            }
            Assert.AreEqual(8, messagesTotal);
            Assert.AreEqual(0, sentTextMessageIndex);
            #endregion

            var updatedMessageContent = "This is message 0 content updated";
            var messageId = messagesMapping[0].Id;
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

            CommunicationUser memberToBeRemoved = user4;
            await chatThreadClient.RemoveMemberAsync(user: memberToBeRemoved);
            AsyncPageable<ChatThreadMember> chatThreadMembersAfterOneDeleted = chatThreadClient.GetMembersAsync();
            var chatThreadMembersAfterOneDeletedCount = chatThreadMembersAfterOneDeleted.ToEnumerableAsync().Result.Count;

            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();
            await chatThreadClient.SendTypingNotificationAsync();

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatThread.Members.Count);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content);
            Assert.AreEqual(ChatMessagePriority.Normal, messagesMapping[0].Priority);

            for (int index = 1; index < 6; index++)
            {
                Assert.AreEqual(string.Format(messageTemplate, index), messagesMapping[index].Content);
                Assert.AreEqual(string.Format(displayNameTemplate, index), messagesMapping[index].SenderDisplayName);
                Assert.AreEqual(ChatMessagePriority.High, messagesMapping[index].Priority);
            }

            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(8, getMessagesCountThread1); // Including all types : 5 text messages, 3 control messages
            Assert.AreEqual(3, getMessagesCountThread2); // Including all types : 1 text message, 2 control messages

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
            (CommunicationUser user1, string token1) = await CreateUserAndTokenAsync(communicationIdentityClient);
            (CommunicationUser user2, string token2) = await CreateUserAndTokenAsync(communicationIdentityClient);

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

        private ChatMessage ExecuteSendGetMessage(int index, ChatThreadClient chatThreadClient, string messageTemplate, string displayNameTemplate, ChatMessagePriority chatPriority)
        {
            SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage(string.Format(messageTemplate, index), chatPriority, string.Format(displayNameTemplate, index));
            ChatMessage chatMessage = chatThreadClient.GetMessage(sendChatMessageResult.Id);
            return chatMessage;
        }

        private async Task<ChatMessage> ExecuteSendGetMessageAsync(int index, ChatThreadClient chatThreadClient, string messageTemplate, string displayNameTemplate, ChatMessagePriority chatPriority)
        {
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(string.Format(messageTemplate, index), chatPriority, string.Format(displayNameTemplate, index));
            ChatMessage chatMessage = await chatThreadClient.GetMessageAsync(sendChatMessageResult.Id);
            return chatMessage;
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
