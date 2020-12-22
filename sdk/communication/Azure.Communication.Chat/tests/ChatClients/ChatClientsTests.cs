// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.ChatClients
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ChatClientsTests : ClientTestBase
    {
        private const string AllMessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"1\",\"content\":\"Content for async message 1\",\"senderDisplayName\":\"Display Name for async  message 1\",\"createdOn\":\"2020-11-05T01:44:24Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"2\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"2\",\"content\":\"Content for async message 2\",\"senderDisplayName\":\"Display Name for async  message 2\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"3\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"3\",\"content\":\"Content for async message 3\",\"senderDisplayName\":\"Display Name for async  message 3\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"4\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"4\",\"content\":\"Content for async message 4\",\"senderDisplayName\":\"Display Name for async  message 4\",\"createdOn\":\"2020-11-05T01:44:22Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"5\",\"type\":\"Text\",\"priority\":\"Normal\",\"version\":\"5\",\"content\":\"Content for async message 5\",\"senderDisplayName\":\"Display Name for async  message 5\",\"createdOn\":\"2020-11-05T01:44:21Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f\"},{\"id\":\"6\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"6\",\"content\":\"<topicupdate><eventtime>1604540653896</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Updated topic - C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"7\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"7\",\"content\":\"<topicupdate><eventtime>1604540653340</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Thread async from C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"8\",\"type\":\"ThreadActivity/AddMember\",\"priority\":\"Normal\",\"version\":\"8\",\"content\":\"<addmember><eventtime>1604540653315</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><rosterVersion>1604540653270</rosterVersion><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</id></detailedtargetinfo></addmember>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"}]}";
        private const string Page1MessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"1\",\"content\":\"Content for async message 1\",\"senderDisplayName\":\"Display Name for async  message 1\",\"createdOn\":\"2020-11-05T01:44:24Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"2\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"2\",\"content\":\"Content for async message 2\",\"senderDisplayName\":\"Display Name for async  message 2\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"3\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"3\",\"content\":\"Content for async message 3\",\"senderDisplayName\":\"Display Name for async  message 3\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"4\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"4\",\"content\":\"Content for async message 4\",\"senderDisplayName\":\"Display Name for async  message 4\",\"createdOn\":\"2020-11-05T01:44:22Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"}],\"nextLink\":\"nextLink\"}";
        private const string Page2MessagesApiResponsePayload = "{\"value\":[{\"id\":\"5\",\"type\":\"Text\",\"priority\":\"Normal\",\"version\":\"5\",\"content\":\"Content for async message 5\",\"senderDisplayName\":\"Display Name for async  message 5\",\"createdOn\":\"2020-11-05T01:44:21Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f\"},{\"id\":\"6\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"6\",\"content\":\"<topicupdate><eventtime>1604540653896</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Updated topic - C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"7\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"7\",\"content\":\"<topicupdate><eventtime>1604540653340</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Thread async from C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"8\",\"type\":\"ThreadActivity/AddMember\",\"priority\":\"Normal\",\"version\":\"8\",\"content\":\"<addmember><eventtime>1604540653315</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><rosterVersion>1604540653270</rosterVersion><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</id></detailedtargetinfo></addmember>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"}]}";

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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
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
                if (message.Type == "Text")
                {
                    textMessagesCounter++;
                    Assert.AreEqual($"Content for async message {idCounter}", message.Content);
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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
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
                    if (message.Type == "Text")
                    {
                        textMessagesCounter++;
                        Assert.AreEqual($"Content for async message {idCounter}", message.Content);
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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var mockResponse = new MockResponse(201);
            mockResponse.SetContent(CreateChatThreadWithErrorsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            //act
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
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
            var communicationUserCredential = new CommunicationUserCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var mockResponse = new MockResponse(201);
            mockResponse.SetContent(AddParticipantsdWithErrorsApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(mockResponse)
            };

            //act
            var chatClient = new ChatClient(uri, communicationUserCredential, chatClientOptions);
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId);
            AddChatParticipantsResult addChatParticipantsResult = await chatThreadClient.AddParticipantsAsync(new List<ChatParticipant>());

            //assert
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(addChatParticipantsResult.Errors.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");
            Assert.AreEqual(3, addChatParticipantsResult.Errors.InvalidParticipants.Count);
        }

        private void AsssertParticipantError(ChatError chatParticipantError, string expectedMessage, string expectedTarget)
        {
            Assert.AreEqual(expectedMessage, chatParticipantError.Message);
            Assert.AreEqual(expectedTarget, chatParticipantError.Target);
        }

    }
}
