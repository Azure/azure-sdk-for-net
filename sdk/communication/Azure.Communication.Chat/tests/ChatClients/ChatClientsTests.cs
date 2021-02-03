// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.ChatClients
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ChatClientsTests : ClientTestBase
    {
        private const string AllMessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";
        private const string Page1MessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}],\"nextLink\":\"nextLink\"}";
        private const string Page2MessagesApiResponsePayload = "{\"value\":[{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiator\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";

        private const string AllReadReceiptsApiResponsePayload = "{\"value\":[{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\",\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\",\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\",\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\",\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\",\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";
        private const string Page1ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\",\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\",\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\",\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"}],\"nextLink\":\"nextLink\"}";
        private const string Page2ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\",\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\",\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";

        private const string CreateChatThreadWithErrorsApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing errors\",\"createdOn\":\"2020-12-18T18:14:33Z\",\"createdBy\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"},\"errors\":{\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\"},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\"}]}}";
        private const string AddParticipantsdWithErrorsApiResponsePayload = "{\"errors\":{\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\"},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\"}]}}";

        public ChatClientsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task OrderInGetMessagesIteratorIsNotAltered()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            var uri = new Uri("https://localHostTest");
            var responseAllItems = new MockResponse(200);
            responseAllItems.SetContent(AllMessagesApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseAllItems)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();

            //assert
            int idCounter = 0;
            int textMessagesCounter = 0;
            await foreach (ChatMessage message in allMessages)
            {
                idCounter++;
                Assert.AreEqual($"{idCounter}", message.Id);
                Assert.AreEqual($"{idCounter}", message.Version);
                if (message.Type == "text")
                {
                    textMessagesCounter++;
                    Assert.AreEqual($"Content for async message{idCounter}", message.Content.Message);
                }
            }
            Assert.AreEqual(8, idCounter);
            Assert.AreEqual(5, textMessagesCounter);
        }

        [Test]
        public async Task OrderInGetMessagesIteratorIsNotAlteredByPaging()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            var uri = new Uri("https://localHostTest");

            var responseItemsPage1 = new MockResponse(200);
            responseItemsPage1.SetContent(Page1MessagesApiResponsePayload);

            var responseItemsPage2 = new MockResponse(200);
            responseItemsPage2.SetContent(Page2MessagesApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseItemsPage1, responseItemsPage2)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();

            //assert
            int pages = 0;
            int idCounter = 0;
            int textMessagesCounter = 0;

            await foreach (Page<ChatMessage> page in allMessages.AsPages(pageSizeHint: 4))
            {
                pages++;
                foreach (ChatMessage message in page.Values)
                {
                    idCounter++;
                    Assert.AreEqual($"{idCounter}", message.Id);
                    Assert.AreEqual($"{idCounter}", message.Version);
                    if (message.Type == "text")
                    {
                        textMessagesCounter++;
                        Assert.AreEqual($"Content for async message{idCounter}", message.Content.Message);
                    }
                }
            }
            Assert.AreEqual(2, pages);
            Assert.AreEqual(8, idCounter);
            Assert.AreEqual(5, textMessagesCounter);
        }

        [Test]
        public async Task OrderInGetReadReceiptsIteratorIsNotAltered()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            var baseSenderId = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d00010";
            var baseReadOnDate = DateTimeOffset.Parse("2020-12-15T00:00:00Z");
            var uri = new Uri("https://localHostTest");
            var responseAllItems = new MockResponse(200);
            responseAllItems.SetContent(AllReadReceiptsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseAllItems)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);

            AsyncPageable<ChatMessageReadReceipt> allReadReceipts = chatThreadClient.GetReadReceiptsAsync();

            //assert
            int idCounter = 0;
            await foreach (ChatMessageReadReceipt readReceipt in allReadReceipts)
            {
                idCounter++;
                Assert.AreEqual($"{idCounter}", readReceipt.ChatMessageId);
                Assert.AreEqual($"{baseSenderId}{idCounter}", readReceipt.SenderId);
                Assert.AreEqual(baseReadOnDate.AddSeconds(idCounter), readReceipt.ReadOn);
            }
            Assert.AreEqual(5, idCounter);
        }
        [Test]
        public async Task OrderInGetReadReceiptsIteratorIsNotAlteredByPaging()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            var uri = new Uri("https://localHostTest");
            var baseSenderId = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d00010";
            var baseReadOnDate = DateTimeOffset.Parse("2020-12-15T00:00:00Z");

            var responseItemsPage1 = new MockResponse(200);
            responseItemsPage1.SetContent(Page1ReadReceiptsApiResponsePayload);

            var responseItemsPage2 = new MockResponse(200);
            responseItemsPage2.SetContent(Page2ReadReceiptsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseItemsPage1, responseItemsPage2)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            AsyncPageable<ChatMessageReadReceipt> allreadReceipts = chatThreadClient.GetReadReceiptsAsync();

            //assert
            int pages = 0;
            int idCounter = 0;
            //string? continuationToken = null;
            await foreach (Page<ChatMessageReadReceipt> page in allreadReceipts.AsPages(pageSizeHint: 3))
            {
                pages++;
                foreach (ChatMessageReadReceipt readReceipt in page.Values)
                {
                    idCounter++;
                    Assert.AreEqual($"{idCounter}", readReceipt.ChatMessageId);
                    Assert.AreEqual($"{baseSenderId}{idCounter}", readReceipt.SenderId);
                    Assert.AreEqual(baseReadOnDate.AddSeconds(idCounter), readReceipt.ReadOn);
                }
                //continuationToken = page.ContinuationToken;
            }
            Assert.AreEqual(2, pages);
            Assert.AreEqual(5, idCounter);
        }

        [Test]
        public async Task CreateChatThreadShouldExposePartialErrors()
        {
            //arrange
            var uri = new Uri("https://localHostTest");
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var mockResponse = new MockResponse(201);
            mockResponse.SetContent(CreateChatThreadWithErrorsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            //act
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync("", new List<ChatParticipant>());

            //assert
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");

            Assert.AreEqual(3, createChatThreadResult.Errors.InvalidParticipants.Count);
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", createChatThreadResult.ChatThread.CreatedBy.Id);
            Assert.AreEqual("Topic for testing errors", createChatThreadResult.ChatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", createChatThreadResult.ChatThread.Id);
        }

        [Test]
        public async Task AddParticipantsShouldExposePartialErrors()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            var uri = new Uri("https://localHostTest");
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var mockResponse = new MockResponse(201);
            mockResponse.SetContent(AddParticipantsdWithErrorsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            //act
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            AddChatParticipantsResult addChatParticipantsResult = await chatThreadClient.AddParticipantsAsync(new List<ChatParticipant>());

            //assert
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");
            Assert.AreEqual(3, addChatParticipantsResult.Errors.InvalidParticipants.Count);
        }

        private void AsssertParticipantError(CommunicationError chatParticipantError, string expectedMessage, string expectedTarget)
        {
            Assert.AreEqual(expectedMessage, chatParticipantError.Message);
            Assert.AreEqual(expectedTarget, chatParticipantError.Target);
        }
    }
}
