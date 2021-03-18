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
        private const string AllMessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";
        private const string Page1MessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}],\"nextLink\":\"nextLink\"}";
        private const string Page2MessagesApiResponsePayload = "{\"value\":[{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";

        private const string AllReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\"},\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\"},\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\"},\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\"},\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\"},\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";
        private const string Page1ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\"},\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\"},\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\"},\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"}],\"nextLink\":\"nextLink\"}";
        private const string Page2ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\"},\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\"},\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";

        private const string CreateChatThreadWithErrorsApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing errors\",\"createdOn\":\"2020-12-18T18:14:33Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"}},\"errors\":{\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\"},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\"}]}}";
        private const string AddParticipantsdWithErrorsApiResponsePayload = "{\"errors\":{\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\"},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\"}]}}";

        private const string CreateChatThreadSuccessApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing success\",\"createdOn\":\"2021-02-25T22:34:48Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\",\"communicationUser\":{\"id\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"}}}}";

        // TODO:
        private const string CreateChatThreadWithExpiredTokenFailureApiResponsePayload = "";

        private const string GetThreadApiResponsePayload = "{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Test Thread\",\"createdOn\":\"2021-02-26T00:46:08Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"communicationUser\":{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}}";

        private const string SendMessageApiResponsePayload = "{\"id\":\"1\"}";

        // TODO:
        private const string SendMessageToDeletedThreadApiResponsePayload = "{}";
        private const string UpdateTopicOfDeletedThreadApiResponsePayload = "{}";

        private const string GetTextMessageApiResponsePayload = "{\"id\":\"1\",\"type\":\"text\",\"sequenceId\":\"1\",\"version\":\"1\",\"content\":{\"message\":\"Test Message\"},\"senderDisplayName\":\"DisplayName for Test Message\",\"createdOn\":\"2021-02-26T00:30:19Z\",\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"communicationUser\":{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}}";
        private const string GetTopicUpdatedMessageApiResponsePayload = "{\"id\":\"2\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"topic\":\"TopicUpdateTest\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantAddedMessageApiResponsePayload = "{\"id\":\"3\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantRemovedMessageApiResponsePayload = "{\"id\":\"4\",\"type\":\"participantRemoved\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantsApiResponsePayload = "{\"value\":[{\"communicationIdentifier\":{\"rawId\":\"1\",\"communicationUser\":{\"id\":\"1\"}},\"displayName\":\"Display Name 1\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"2\",\"communicationUser\":{\"id\":\"2\"}},\"displayName\":\"Display Name 2\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}]}";

        private const string AddParticipantApiResponsePayload = "{}";
        private const string AddParticipantsApiResponsePayload = "{}";
        private const string GetThreadsApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"topic\":\"Test Thread 1\",\"lastMessageReceivedOn\":\"2021-02-26T00:46:09Z\"},{\"id\":\"2\",\"topic\":\"Test Thread 2\",\"lastMessageReceivedOn\":\"2021-02-25T23:38:20Z\"},{\"id\":\"3\",\"topic\":\"Test Thread 3\",\"lastMessageReceivedOn\":\"2021-02-25T23:33:29Z\"}]}";

        public ChatClientsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task OrderInGetMessagesIteratorIsNotAltered()
        {
            //arange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, AllMessagesApiResponsePayload);

            //act
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
            var baseSenderId = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d00010";
            var baseReadOnDate = DateTimeOffset.Parse("2020-12-15T00:00:00Z");
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, AllReadReceiptsApiResponsePayload);

            //act
            AsyncPageable<ChatMessageReadReceipt> allReadReceipts = chatThreadClient.GetReadReceiptsAsync();

            //assert
            int idCounter = 0;
            await foreach (ChatMessageReadReceipt readReceipt in allReadReceipts)
            {
                idCounter++;
                Assert.AreEqual($"{idCounter}", readReceipt.ChatMessageId);
                Assert.AreEqual($"{baseSenderId}{idCounter}", ((UnknownIdentifier)readReceipt.Sender).Id);
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
                    Assert.AreEqual($"{baseSenderId}{idCounter}", ((UnknownIdentifier)readReceipt.Sender).Id);
                    Assert.AreEqual(baseReadOnDate.AddSeconds(idCounter), readReceipt.ReadOn);
                }
                //continuationToken = page.ContinuationToken;
            }
            Assert.AreEqual(2, pages);
            Assert.AreEqual(5, idCounter);
        }

        [Test]
        public async Task CreateChatThreadShouldSucceed()
        {
            //act
            var chatClient = CreateMockChatClient(201, CreateChatThreadSuccessApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync("", new List<ChatParticipant>() { chatParticipant });

            //assert
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", CommunicationIdentifierSerializer.Serialize(createChatThreadResult.ChatThread.CreatedBy).CommunicationUser.Id);
            Assert.AreEqual("Topic for testing success", createChatThreadResult.ChatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", createChatThreadResult.ChatThread.Id);
        }

        [Test]
        public async Task SendMessageShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, SendMessageApiResponsePayload);

            //act
            string messageId = await chatThreadClient.SendMessageAsync("Send Message Test");

            //assert
            Assert.AreEqual("1", messageId);
        }

        [Test]
        public async Task SendTypingIndicatorShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200);

            //act
            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync();

            //assert
            Assert.AreEqual(200, typingNotificationResponse.Status);
        }

        [Test]
        public async Task SendReadReceiptShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200);

            //act
            Response readReceiptResponse = await chatThreadClient.SendReadReceiptAsync(messageId);

            //assert
            Assert.AreEqual(200, readReceiptResponse.Status);
        }

        [Test]
        public async Task DeleteMessagShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            Response readReceiptResponse = await chatThreadClient.DeleteMessageAsync(messageId);

            //assert
            Assert.AreEqual(204, readReceiptResponse.Status);
        }

        [Test]
        public async Task UpdateMessagShouldSucceed()
        {
            //arrange
            var messageId = "1";
            var content = "Update Message Test";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            Response updateMessageResponse = await chatThreadClient.UpdateMessageAsync(messageId, content);

            //assert
            Assert.AreEqual(204, updateMessageResponse.Status);
        }

        [Test]
        public async Task GetTextMessageShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetTextMessageApiResponsePayload);

            //act
            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.Text, message.Type);
            Assert.AreEqual("1", message.Id);
            Assert.AreEqual("Test Message", message.Content.Message);
            Assert.AreEqual("DisplayName for Test Message", message.SenderDisplayName);
            Assert.NotNull(message.Sender);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Sender!).CommunicationUser.Id);
        }

        [Test]
        public async Task GetTopicUpdatedMessageShouldSucceed()
        {
            //arrange
            var messageId = "2";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetTopicUpdatedMessageApiResponsePayload);

            //act
            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.TopicUpdated, message.Type);
            Assert.AreEqual("2", message.Id);
            Assert.AreEqual("TopicUpdateTest", message.Content.Topic);
            Assert.AreEqual("2", message.Version);
            Assert.NotNull(message.Content.Initiator);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Content.Initiator!).RawId);
        }

        [Test]
        public async Task GetParticipantAddedMessageShouldSucceed()
        {
            //arrange
            var messageId = "3";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetParticipantAddedMessageApiResponsePayload);

            //act
            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.ParticipantAdded, message.Type);
            Assert.AreEqual("3", message.Id);
            Assert.AreEqual("3", message.Version);
            Assert.AreEqual(2, message.Content.Participants.Count);
            Assert.NotNull(message.Content.Initiator);
            Assert.NotNull(message.Content.Participants[0].User);
            Assert.NotNull(message.Content.Participants[1].User);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Content.Initiator!).RawId);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9", CommunicationIdentifierSerializer.Serialize(message.Content.Participants[0].User!).RawId);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Content.Participants[1].User!).RawId);
        }

        [Test]
        public async Task GetParticipantRemovedMessageShouldSucceed()
        {
            //arrange
            var messageId = "4";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetParticipantRemovedMessageApiResponsePayload);

            //act
            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.ParticipantRemoved, message.Type);
            Assert.AreEqual("4", message.Id);
            Assert.AreEqual("4", message.Version);
            Assert.AreEqual(1, message.Content.Participants.Count);
            Assert.NotNull(message.Content.Initiator);
            Assert.NotNull(message.Content.Participants[0].User);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Content.Initiator!).RawId);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9", CommunicationIdentifierSerializer.Serialize(message.Content.Participants[0].User!).RawId);
        }
        [Test]
        public async Task GetThreadShouldSucceed()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            ChatClient chatClient = CreateMockChatClient(200, GetThreadApiResponsePayload);

            //act
            ChatThread chatThread = await chatClient.GetChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(threadId, chatThread.Id);
            Assert.AreEqual("Test Thread", chatThread.Topic);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(chatThread.CreatedBy).CommunicationUser.Id);
        }

        [Test]
        public async Task UpdateThreadTopicShouldSucceed()
        {
            //arrange
            var topic = "Update Thread Topic";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            Response UpdateTopiceResponse = await chatThreadClient.UpdateTopicAsync(topic);

            //assert
            Assert.AreEqual(204, UpdateTopiceResponse.Status);
        }

        [Test]
        public async Task GetThreadsShouldSucceed()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(200, GetThreadsApiResponsePayload);

            //act
            AsyncPageable<ChatThreadInfo> chatThreadsInfo = chatClient.GetChatThreadsInfoAsync();

            //assert

            int idCounter = 0;
            await foreach (ChatThreadInfo chatThread in chatThreadsInfo)
            {
                idCounter++;
                Assert.AreEqual($"{idCounter}", chatThread.Id);
                Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
            }
            Assert.AreEqual(3, idCounter);
        }

        [Test]
        public async Task GetParticipantsShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetParticipantsApiResponsePayload);

            //act
            AsyncPageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipantsAsync();

            //assert
            int idCounter = 0;
            await foreach (ChatParticipant chatParticipant in chatParticipants)
            {
                idCounter++;
                Assert.AreEqual($"{idCounter}", CommunicationIdentifierSerializer.Serialize(chatParticipant.User).CommunicationUser.Id);
                Assert.AreEqual($"Display Name {idCounter}", chatParticipant.DisplayName);
            }
            Assert.AreEqual(2, idCounter);
        }

        [Test]
        public async Task RemoveParticipantShouldSucceed()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            CommunicationUserIdentifier identifier = new CommunicationUserIdentifier(id);
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204, GetParticipantsApiResponsePayload);

            //act
            Response RemoveParticipantResponse = await chatThreadClient.RemoveParticipantAsync(identifier);

            //assert
            Assert.AreEqual(204, RemoveParticipantResponse.Status);
        }

        [Test]
        public async Task AddParticipantShouldSucceed()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            ChatParticipant chatParticipant = new ChatParticipant(new CommunicationUserIdentifier(id));
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantApiResponsePayload);

            //act
            AddChatParticipantsResult AddParticipantResponse = await chatThreadClient.AddParticipantAsync(chatParticipant);

            //assert
            Assert.IsNull(AddParticipantResponse.Errors);
        }

        [Test]
        public async Task AddParticipantsShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantsApiResponsePayload);

            //act
            AddChatParticipantsResult AddParticipantsResponse = await chatThreadClient.AddParticipantsAsync(new List<ChatParticipant>());

            //assert
            Assert.IsNull(AddParticipantsResponse.Errors);
        }

        [Test]
        public async Task DeleteChatThreadShouldSucceed()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            ChatClient chatClient = CreateMockChatClient(204);

            //act
            Response deleteChatThreadResponse = await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(204, deleteChatThreadResponse.Status);
        }

        [Test]
        public async Task CreateChatThreadShouldExposePartialErrors()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(201, CreateChatThreadWithErrorsApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));

            //act
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync("", new List<ChatParticipant>() { chatParticipant});

            //assert
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(createChatThreadResult.Errors.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");

            Assert.AreEqual(3, createChatThreadResult.Errors.InvalidParticipants.Count);
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", CommunicationIdentifierSerializer.Serialize(createChatThreadResult.ChatThread.CreatedBy).RawId);
            Assert.AreEqual("Topic for testing errors", createChatThreadResult.ChatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", createChatThreadResult.ChatThread.Id);
        }

        [Test]
        public async Task AddParticipantsShouldExposePartialErrors()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantsdWithErrorsApiResponsePayload);

            //act
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

        private ChatClient CreateMockChatClient(int responseCode, string? responseContent = null)
        {
            var uri = new Uri("https://localHostTest");
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var mockResponse = new MockResponse(responseCode);
            if (responseContent != null)
            {
                mockResponse.SetContent(responseContent);
            }

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            return new ChatClient(uri, communicationTokenCredential, chatClientOptions);
        }

        private ChatThreadClient CreateMockChatThreadClient(int responseCode, string? responseContent = null, string threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2")
        {
            return CreateMockChatClient(responseCode, responseContent).GetChatThreadClient(threadId);
        }
    }
}
