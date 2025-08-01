// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.ChatClients
{
    public class ChatClientsTests : ClientTestBase
    {
        private const string AllMessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";
        private const string Page1MessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"1\",\"content\":{\"message\":\"Content for async message1\"},\"senderDisplayName\":\"DisplayName for async message1\",\"createdOn\":\"2021-01-11T03:47:00Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"2\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"message\":\"Content for async message2\"},\"senderDisplayName\":\"DisplayName for async message2\",\"createdOn\":\"2021-01-11T03:46:54Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"3\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"message\":\"Content for async message3\"},\"senderDisplayName\":\"DisplayName for async message3\",\"createdOn\":\"2021-01-11T03:46:48Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"4\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"message\":\"Content for async message4\"},\"senderDisplayName\":\"DisplayName for async message4\",\"createdOn\":\"2021-01-11T03:46:43Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}],\"nextLink\":\"nextLink\"}";
        private const string Page2MessagesApiResponsePayload = "{\"value\":[{\"id\":\"5\",\"type\":\"text\",\"priority\":\"normal\",\"version\":\"5\",\"content\":{\"message\":\"Content for async message5\"},\"senderDisplayName\":\"DisplayName for async message5\",\"createdOn\":\"2021-01-11T03:46:36Z\",\"SenderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},{\"id\":\"6\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"6\",\"content\":{\"topic\":\"Updatedtopic-C#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:44:41Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"7\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"7\",\"content\":{\"topic\":\"ThreadasyncfromC#sdk\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"},{\"id\":\"8\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"8\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}]}";

        private const string AllReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\"},\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\"},\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\"},\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\"},\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\"},\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";
        private const string Page1ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101\"},\"chatMessageId\":\"1\",\"readOn\":\"2020-12-15T00:00:01Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000102\"},\"chatMessageId\":\"2\",\"readOn\":\"2020-12-15T00:00:02Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000103\"},\"chatMessageId\":\"3\",\"readOn\":\"2020-12-15T00:00:03Z\"}],\"nextLink\":\"nextLink\"}";
        private const string Page2ReadReceiptsApiResponsePayload = "{\"value\":[{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000104\"},\"chatMessageId\":\"4\",\"readOn\":\"2020-12-15T00:00:04Z\"},{\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000105\"},\"chatMessageId\":\"5\",\"readOn\":\"2020-12-15T00:00:05Z\"}]}";

        private const string CreateChatThreadWithErrorsApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing errors\",\"createdOn\":\"2020-12-18T18:14:33Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"}},\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\",\"details\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"}],\"innererror\":{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"}},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\",\"innererror\":{}}]}";

        private const string AddParticipantsdWithErrorsApiResponsePayload = "{\"invalidParticipants\":[{\"code\":\"404\",\"message\":\"Not found\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677\"},{\"code\":\"401\",\"message\":\"Authentication failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678\"},{\"code\":\"403\",\"message\":\"Permissions check failed\",\"target\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679\"}]}";

        private const string CreateChatThreadSuccessApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing success\",\"createdOn\":\"2021-02-25T22:34:48Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\",\"communicationUser\":{\"id\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"}},\"metadata\": {\"MetaKey1\":\"MetaValue1\",\"MetaKey2\": \"MetaValue2\"}, \"retentionPolicy\":{ \"kind\":\"threadCreationDate\", \"deleteThreadAfterDays\":40 }}}";
        private const string CreateChatThreadNoneRetentionSuccessApiResponsePayload = "{\"chatThread\":{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Topic for testing success\",\"createdOn\":\"2021-02-25T22:34:48Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\",\"communicationUser\":{\"id\":\"8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c\"}},\"metadata\": {\"MetaKey1\":\"MetaValue1\",\"MetaKey2\": \"MetaValue2\"}, \"retentionPolicy\":{ \"kind\":\"none\"}}}";

        private const string GetThreadApiResponsePayload = "{\"id\":\"19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2\",\"topic\":\"Test Thread\",\"createdOn\":\"2021-02-26T00:46:08Z\",\"createdByCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"communicationUser\":{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}}";

        private const string SendMessageApiResponsePayload = "{\"id\":\"1\"}";

        private const string GetTextMessageApiResponsePayload = "{\"id\":\"1\",\"type\":\"text\",\"sequenceId\":\"1\",\"version\":\"1\",\"content\":{\"message\":\"Test Message\"},\"senderDisplayName\":\"DisplayName for Test Message\",\"createdOn\":\"2021-02-26T00:30:19Z\",\"senderCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\",\"communicationUser\":{\"id\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}}}";
        private const string GetTopicUpdatedMessageApiResponsePayload = "{\"id\":\"2\",\"type\":\"topicUpdated\",\"priority\":\"normal\",\"version\":\"2\",\"content\":{\"topic\":\"TopicUpdateTest\",\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:35Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantAddedMessageApiResponsePayload = "{\"id\":\"3\",\"type\":\"participantAdded\",\"priority\":\"normal\",\"version\":\"3\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantRemovedMessageApiResponsePayload = "{\"id\":\"4\",\"type\":\"participantRemoved\",\"priority\":\"normal\",\"version\":\"4\",\"content\":{\"participants\":[{\"communicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d0002c9\"},\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}],\"initiatorCommunicationIdentifier\":{\"rawId\":\"8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7\"}},\"createdOn\":\"2021-01-11T03:30:34Z\",\"senderId\":\"19:5f2ad13282c449c894a2a388f9d9ddd9@thread.v2\"}";
        private const string GetParticipantsApiResponsePayload = "{\"value\":[{\"communicationIdentifier\":{\"rawId\":\"1\",\"communicationUser\":{\"id\":\"1\"}},\"displayName\":\"Display Name 1\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"},{\"communicationIdentifier\":{\"rawId\":\"2\",\"communicationUser\":{\"id\":\"2\"}},\"displayName\":\"Display Name 2\",\"shareHistoryTime\":\"1970-01-01T00:00:00Z\"}]}";

        private const string AddParticipantApiResponsePayload = "{}";
        private const string AddParticipantsApiResponsePayload = "{}";
        private const string GetThreadsApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"topic\":\"Test Thread 1\",\"lastMessageReceivedOn\":\"2021-02-26T00:46:09Z\"},{\"id\":\"2\",\"topic\":\"Test Thread 2\",\"lastMessageReceivedOn\":\"2021-02-25T23:38:20Z\"},{\"id\":\"3\",\"topic\":\"Test Thread 3\",\"lastMessageReceivedOn\":\"2021-02-25T23:33:29Z\",\"deletedOn\":null},{\"id\":\"4\",\"topic\":\"Test Thread 4\",\"lastMessageReceivedOn\":null,\"deletedOn\":\"2021-02-25T23:38:20Z\"},{}]}";

        private const string GetThreadsApiResponsePayloadPage1 = "{\"value\":[{\"id\":\"1\",\"topic\":\"Test Thread 1\",\"lastMessageReceivedOn\":\"2021-02-26T00:46:09Z\"},{\"id\":\"2\",\"topic\":\"Test Thread 2\",\"lastMessageReceivedOn\":\"2021-02-25T23:38:20Z\"},{\"id\":\"3\",\"topic\":\"Test Thread 3\",\"lastMessageReceivedOn\":\"2021-02-25T23:33:29Z\"}],\"nextLink\":\"nextLink\"}";

        private const string GetThreadsApiResponsePayloadPage2 = "{\"value\":[{\"id\":\"4\",\"topic\":\"Test Thread 4\",\"lastMessageReceivedOn\":\"2021-02-26T00:46:09Z\"},{\"id\":\"5\",\"topic\":\"Test Thread 5\",\"lastMessageReceivedOn\":\"2021-02-25T23:38:20Z\"},{\"id\":\"6\",\"topic\":\"Test Thread 6\",\"lastMessageReceivedOn\":\"2021-02-25T23:33:29Z\"}]}";

        private const string GetThreadsApiResponseEmptyPayload = "{}";

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
            var communicationTokenCredential = new CommunicationTokenCredential(ChatLiveTestBase.SanitizedUnsignedUserTokenValue);
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
        public async Task OrderInGetReadReceiptsAsyncIteratorIsNotAltered()
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
        public void OrderInGetReadReceiptsIteratorIsNotAltered()
        {
            //arrange
            var baseSenderId = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d00010";
            var baseReadOnDate = DateTimeOffset.Parse("2020-12-15T00:00:00Z");
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, AllReadReceiptsApiResponsePayload);

            //act
            var allReadReceipts = chatThreadClient.GetReadReceipts();

            //assert
            int idCounter = 0;
            foreach (ChatMessageReadReceipt readReceipt in allReadReceipts)
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
            var communicationTokenCredential = new CommunicationTokenCredential(ChatLiveTestBase.SanitizedUnsignedUserTokenValue);
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
        public async Task CreateChatThreadAsyncShouldSucceed()
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
        public void CreateChatThreadShouldSucceed()
        {
            //act
            var chatClient = CreateMockChatClient(201, CreateChatThreadSuccessApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread("", new List<ChatParticipant>() { chatParticipant });

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
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync("Send Message Test");

            //assert
            Assert.AreEqual("1", sendChatMessageResult.Id);
        }

        [Test]
        public async Task SendMessageAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync("Send Message Test");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void SendMessageShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                SendChatMessageResult sendChatMessageResult = chatThreadClient.SendMessage("Send Message Test");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task SendMessageWithOptionsShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, SendMessageApiResponsePayload);

            //act
            SendChatMessageOptions sendChatMessageOptions = new() { Content = "Send Message Test" };
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(sendChatMessageOptions);

            //assert
            Assert.AreEqual("1", sendChatMessageResult.Id);
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
        public void SendTypingIndicatorShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            //act
            try
            {
                var res = chatThreadClient.SendTypingNotification();
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task SendTypingIndicatorAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            //act
            try
            {
                var res = await chatThreadClient.SendTypingNotificationAsync();
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task SendTypingIndicatorWithOptionsShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200);
            TypingNotificationOptions options = new TypingNotificationOptions { SenderDisplayName = "display name test" };

            //act
            Response typingNotificationResponse = await chatThreadClient.SendTypingNotificationAsync(options);

            //assert
            Assert.AreEqual(200, typingNotificationResponse.Status);
        }

        [Test]
        public async Task SendReadReceiptAsyncShouldSucceed()
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
        public void SendReadReceiptShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200);

            //act
            Response readReceiptResponse = chatThreadClient.SendReadReceipt(messageId);

            //assert
            Assert.AreEqual(200, readReceiptResponse.Status);
        }

        [Test]
        public async Task SendReadReceiptAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            //act
            try
            {
                var messageId = "1";
                var res = await chatThreadClient.SendReadReceiptAsync(messageId);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void SendReadReceiptShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            //act
            try
            {
                var messageId = "1";
                var res = chatThreadClient.SendReadReceipt(messageId);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task DeleteMessageAsyncShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            var response = await chatThreadClient.DeleteMessageAsync(messageId);

            //assert
            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public void DeleteMessageShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            var response = chatThreadClient.DeleteMessage(messageId);

            //assert
            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task DeleteMessageAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            var messageId = "1";
            //act
            try
            {
                var res = await chatThreadClient.DeleteMessageAsync(messageId);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void DeleteMessageShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            var messageId = "1";
            //act
            try
            {
                var res = chatThreadClient.DeleteMessage(messageId);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task UpdateMessagAsyncShouldSucceed()
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
        public async Task UpdateMessageAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            var messageId = "1";
            var content = "Update Message Test";
            //act
            try
            {
                var res = await chatThreadClient.UpdateMessageAsync(messageId, content);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void UpdateMessageShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");
            var messageId = "1";
            var content = "Update Message Test";
            //act
            try
            {
                var res = chatThreadClient.UpdateMessage(messageId, content);
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void UpdateMessagShouldSucceed()
        {
            //arrange
            var messageId = "1";
            var content = "Update Message Test";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            //act
            Response updateMessageResponse = chatThreadClient.UpdateMessage(messageId, content);

            //assert
            Assert.AreEqual(204, updateMessageResponse.Status);
        }

        [Test]
        public async Task GetTextMessageAsyncShouldSucceed()
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
        public async Task GetMessageAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var res = await chatThreadClient.GetMessageAsync("id");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void GetMessageShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var sendChatMessageResult = chatThreadClient.GetMessage("id");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void GetTextMessageShouldSucceed()
        {
            //arrange
            var messageId = "1";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetTextMessageApiResponsePayload);

            //act
            ChatMessage message = chatThreadClient.GetMessage(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.Text, message.Type);
            Assert.AreEqual("1", message.Id);
            Assert.AreEqual("Test Message", message.Content.Message);
            Assert.AreEqual("DisplayName for Test Message", message.SenderDisplayName);
            Assert.NotNull(message.Sender);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Sender!).CommunicationUser.Id);
        }
        [Test]
        public async Task GetTopicUpdatedMessageAsyncShouldSucceed()
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
        public void GetTopicUpdatedMessageShouldSucceed()
        {
            //arrange
            var messageId = "2";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetTopicUpdatedMessageApiResponsePayload);

            //act
            ChatMessage message = chatThreadClient.GetMessage(messageId);

            //assert
            Assert.AreEqual(ChatMessageType.TopicUpdated, message.Type);
            Assert.AreEqual("2", message.Id);
            Assert.AreEqual("TopicUpdateTest", message.Content.Topic);
            Assert.AreEqual("2", message.Version);
            Assert.NotNull(message.Content.Initiator);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(message.Content.Initiator!).RawId);
        }

        [Test]
        public async Task GetParticipantAddedMessageAsyncShouldSucceed()
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
        public void GetParticipantAddedMessageShouldSucceed()
        {
            //arrange
            var messageId = "3";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetParticipantAddedMessageApiResponsePayload);

            //act
            ChatMessage message = chatThreadClient.GetMessage(messageId);

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
        public async Task GetParticipantRemovedMessageAsyncShouldSucceed()
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

        public void GetParticipantRemovedMessageShouldSucceed()
        {
            //arrange
            var messageId = "4";
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetParticipantRemovedMessageApiResponsePayload);

            //act
            ChatMessage message = chatThreadClient.GetMessage(messageId);

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
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(200, GetThreadApiResponsePayload);

            //act
            ChatThreadProperties chatThread = await chatThreadClient.GetPropertiesAsync();

            //assert
            Assert.AreEqual(threadId, chatThread.Id);
            Assert.AreEqual("Test Thread", chatThread.Topic);
            Assert.AreEqual("8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-8f5e-776d-ea7c-5a3a0d0027b7", CommunicationIdentifierSerializer.Serialize(chatThread.CreatedBy).CommunicationUser.Id);
        }

        [Test]
        public void GetThreadPropertiesShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var res = chatThreadClient.GetProperties();
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task GetThreadPropertiesAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var result = await chatThreadClient.GetPropertiesAsync();
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
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
        public async Task UpdateThreadTopicAsyncShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var res = await chatThreadClient.UpdateTopicAsync("Send Message Test");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void UpdateThreadTopicShouldThrowError()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401, "{}");

            //act
            try
            {
                var sendChatMessageResult = chatThreadClient.UpdateTopic("Send Message Test");
                throw new Exception("Test failed as expected exception was not thrown in the previous step");
            }
            catch (Exception ex)
            {
                //assert
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task UpdateProperties_TopicOnly_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var options = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Updated Topic"
            };

            var response = await chatThreadClient.UpdatePropertiesAsync(options);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task UpdateProperties_MetadataOnly_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var updateOptionsWithNewMetadata = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew1", "MetaValueNew1");
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew2", "MetaValueNew2");

            var response = await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNewMetadata);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task UpdateProperties_RetentionPolicyToNull_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var options = new UpdateChatThreadPropertiesOptions
            {
                RetentionPolicy = null
            };

            var response = await chatThreadClient.UpdatePropertiesAsync(options);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task UpdateProperties_RetentionPolicyToValue_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var options = new UpdateChatThreadPropertiesOptions();
            options.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(40);

            var response = await chatThreadClient.UpdatePropertiesAsync(options);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task UpdateProperties_TopicAndMetadata_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var options = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Topic + Metadata"
            };
            options.Metadata.Add("MetaKeyNew1", "MetaValueNew1");
            options.Metadata.Add("MetaKeyNew2", "MetaValueNew2");

            var response = await chatThreadClient.UpdatePropertiesAsync(options);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task UpdateProperties_AllFields_Succeeds()
        {
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204);

            var options = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Full Update"
            };

            options.Metadata.Add("MetaKeyNew1", "MetaValueNew1");
            options.Metadata.Add("MetaKeyNew2", "MetaValueNew2");
            options.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(40);

            var response = await chatThreadClient.UpdatePropertiesAsync(options);

            Assert.AreEqual(204, response.Status);
        }

        [Test]
        public async Task GetThreadsAsyncWithDateTimeShouldSucceed()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(200, GetThreadsApiResponsePayload);

            //act
            AsyncPageable<ChatThreadItem> chatThreads = chatClient.GetChatThreadsAsync(It.IsAny<DateTimeOffset>());

            //assert

            int idCounter = 0;

            await foreach (ChatThreadItem chatThread in chatThreads)
            {
                idCounter++;
                if (idCounter == 5 && chatThread?.Id == null)
                {
                    continue;
                }
                Assert.AreEqual($"{idCounter}", chatThread.Id);
                Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
            }
            Assert.AreEqual(5, idCounter);
        }

        [Test]
        public async Task GetThreadsAsyncWithPagesShouldSucceed()
        {
            var uri = new Uri("https://localHostTest");
            var responseItemsPage1 = new MockResponse(200);
            responseItemsPage1.SetContent(GetThreadsApiResponsePayloadPage1);

            var responseItemsPage2 = new MockResponse(200);
            responseItemsPage2.SetContent(GetThreadsApiResponsePayloadPage2);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseItemsPage1, responseItemsPage2)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatLiveTestBase.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            AsyncPageable<ChatThreadItem> chatThreads = chatClient.GetChatThreadsAsync(It.IsAny<DateTimeOffset>());
            int idCounter = 0;
            int pages = 0;
            await foreach (Page<ChatThreadItem> page in chatThreads.AsPages(pageSizeHint: 2))
            {
                pages++;
                foreach (ChatThreadItem chatThread in page.Values)
                {
                    idCounter++;
                    Assert.AreEqual($"{idCounter}", chatThread.Id);
                    Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
                }
            }
            Assert.AreEqual(2, pages);
            Assert.AreEqual(6, idCounter);
        }

        [Test]
        public void GetThreadsWithPagesShouldSucceed()
        {
            var uri = new Uri("https://localHostTest");
            var responseItemsPage1 = new MockResponse(200);
            responseItemsPage1.SetContent(GetThreadsApiResponsePayloadPage1);

            var responseItemsPage2 = new MockResponse(200);
            responseItemsPage2.SetContent(GetThreadsApiResponsePayloadPage2);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseItemsPage1, responseItemsPage2)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatLiveTestBase.SanitizedUnsignedUserTokenValue);
            var chatClient = new ChatClient(uri, communicationTokenCredential, chatClientOptions);
            var chatThreads = chatClient.GetChatThreads(It.IsAny<DateTimeOffset>());
            int idCounter = 0;
            int pages = 0;
            foreach (Page<ChatThreadItem> page in chatThreads.AsPages(pageSizeHint: 2))
            {
                pages++;
                foreach (ChatThreadItem chatThread in page.Values)
                {
                    idCounter++;
                    Assert.AreEqual($"{idCounter}", chatThread.Id);
                    Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
                }
            }
            Assert.AreEqual(2, pages);
            Assert.AreEqual(6, idCounter);
        }

        [Test]
        public async Task GetThreadsAsyncShouldSucceed()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(200, GetThreadsApiResponsePayload);

            //act
            AsyncPageable<ChatThreadItem> chatThreads = chatClient.GetChatThreadsAsync();

            //assert

            int idCounter = 0;
            await foreach (ChatThreadItem chatThread in chatThreads)
            {
                idCounter++;
                if (idCounter == 5 && chatThread?.Id == null)
                {
                    continue;
                }
                Assert.AreEqual($"{idCounter}", chatThread.Id);
                Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
            }
            Assert.AreEqual(5, idCounter);
        }

        [Test]
        public void GetThreadsShouldSucceed()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(200, GetThreadsApiResponsePayload);

            //act
            var chatThreads = chatClient.GetChatThreads();

            //assert

            int idCounter = 0;
            foreach (ChatThreadItem chatThread in chatThreads)
            {
                ++idCounter;
                if (idCounter == 5 && chatThread?.Id == null)
                {
                    continue;
                }
                Assert.AreEqual($"{idCounter}", chatThread.Id);
                Assert.AreEqual($"Test Thread {idCounter}", chatThread.Topic);
            }
            Assert.AreEqual(5, idCounter);
        }

        [Test]
        public void GetThreadsShouldThrowException()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(401);

            //act
            try
            {
                var chatThreads = chatClient.GetChatThreads();
                //if (chatThreads.Any(x=> x.))

                foreach (var c in chatThreads)
                {
                }
                throw new Exception("Test failed. Expected exception when getting chat threads");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("401"));
            }
        }

        [Test]
        public void DeleteThreadsShouldThrowException()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(401);

            //act
            try
            {
                var chatThreads = chatClient.DeleteChatThread("threadID");
                throw new Exception("Test failed. Expected exception when delete chat threads");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task DeleteThreadsAsyncShouldThrowException()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(401);

            //act
            try
            {
                var chatThreads = await chatClient.DeleteChatThreadAsync("threadID");
                throw new Exception("Test failed. Expected exception when delete chat threads");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("401"));
            }
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
        public void RemoveParticipantShouldSucceed()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            CommunicationUserIdentifier identifier = new CommunicationUserIdentifier(id);
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(204, GetParticipantsApiResponsePayload);

            //act
            Response RemoveParticipantResponse = chatThreadClient.RemoveParticipant(identifier);

            //assert
            Assert.AreEqual(204, RemoveParticipantResponse.Status);
        }

        [Test]
        public async Task RemoveParticipantAsyncShouldSucceed()
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
        public void AddParticipantShouldSucceed()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            ChatParticipant chatParticipant = new ChatParticipant(new CommunicationUserIdentifier(id));
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantApiResponsePayload);

            //act
            Response AddParticipantResponse = chatThreadClient.AddParticipant(chatParticipant);

            //assert
            Assert.AreEqual(201, AddParticipantResponse.Status);
        }

        [Test]
        public async Task AddParticipantAsyncShouldSucceed()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            ChatParticipant chatParticipant = new ChatParticipant(new CommunicationUserIdentifier(id));
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantApiResponsePayload);

            //act
            Response AddParticipantResponse = await chatThreadClient.AddParticipantAsync(chatParticipant);

            //assert
            Assert.AreEqual(201, AddParticipantResponse.Status);
        }

        [Test]
        public async Task AddParticipantsAsyncShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantsApiResponsePayload);

            //act
            AddChatParticipantsResult AddParticipantsResponse = await chatThreadClient.AddParticipantsAsync(new List<ChatParticipant>());

            //assert
            Assert.AreEqual(0, AddParticipantsResponse.InvalidParticipants.Count);
        }

        [Test]
        public void AddParticipantsShouldSucceed()
        {
            //arrange
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(201, AddParticipantsApiResponsePayload);

            //act
            AddChatParticipantsResult AddParticipantsResponse = chatThreadClient.AddParticipants(new List<ChatParticipant>());

            //assert
            Assert.AreEqual(0, AddParticipantsResponse.InvalidParticipants.Count);
        }

        [Test]
        public async Task DeleteChatThreadASyncShouldSucceed()
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
        public void DeleteChatThreadShouldSucceed()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            ChatClient chatClient = CreateMockChatClient(204);

            //act
            Response deleteChatThreadResponse = chatClient.DeleteChatThread(threadId);

            //assert
            Assert.AreEqual(204, deleteChatThreadResponse.Status);
        }

        [Test]
        public void DeleteChatThreadShouldThrowException()
        {
            //arrange
            var threadId = "19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2";
            ChatClient chatClient = CreateMockChatClient(401);

            try
            {
                //act
                Response deleteChatThreadResponse = chatClient.DeleteChatThread(threadId);
                throw new Exception("Test failed to throw exception");
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message.Contains("401"));
            }
        }

        [Test]
        public async Task CreateChatThreadAsyncShouldExposePartialErrors()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(201, CreateChatThreadWithErrorsApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));

            //act
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync("", new List<ChatParticipant>() { chatParticipant });

            //assert
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");

            Assert.AreEqual(3, createChatThreadResult.InvalidParticipants.Count);
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", CommunicationIdentifierSerializer.Serialize(createChatThreadResult.ChatThread.CreatedBy).RawId);
            Assert.AreEqual("Topic for testing errors", createChatThreadResult.ChatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", createChatThreadResult.ChatThread.Id);
        }

        [Test]
        public void CreateChatThreadWithThreadRetentionPolicyShouldSucceed()
        {
            //act
            var chatClient = CreateMockChatClient(201, CreateChatThreadSuccessApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread(new CreateChatThreadOptions("new topic") { RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(40) });

            //assert
            var chatThread = createChatThreadResult.ChatThread;
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", CommunicationIdentifierSerializer.Serialize(chatThread.CreatedBy).CommunicationUser.Id);
            Assert.AreEqual("Topic for testing success", chatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", chatThread.Id);

            var threadCreationDateRetentionPolicy = chatThread.RetentionPolicy as ThreadCreationDateRetentionPolicy;

            Assert.IsNotNull(threadCreationDateRetentionPolicy);
            Assert.AreEqual(40, threadCreationDateRetentionPolicy?.DeleteThreadAfterDays);
        }

        [Test]
        public void CreateChatThreadWithNoneRetentionPolicyShouldSucceed()
        {
            //act
            var chatClient = CreateMockChatClient(201, CreateChatThreadNoneRetentionSuccessApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread(new CreateChatThreadOptions("new topic") { RetentionPolicy = ChatRetentionPolicy.None() });

            //assert
            var chatThread = createChatThreadResult.ChatThread;
            Assert.AreEqual("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c", CommunicationIdentifierSerializer.Serialize(chatThread.CreatedBy).CommunicationUser.Id);
            Assert.AreEqual("Topic for testing success", chatThread.Topic);
            Assert.AreEqual("19:e5e7a3fa5f314a01b2d12c6c7b37f433@thread.v2", chatThread.Id);

            var noneRetentionPolicy = chatThread.RetentionPolicy as NoneRetentionPolicy;

            Assert.IsNotNull(noneRetentionPolicy);
        }

        [Test]
        public void CreateChatThreadShouldExposePartialErrors()
        {
            //arrange
            ChatClient chatClient = CreateMockChatClient(201, CreateChatThreadWithErrorsApiResponsePayload);
            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier("8:acs:46849534-eb08-4ab7-bde7-c36928cd1547_00000007-165c-9b10-b0b7-3a3a0d00076c"));

            //act
            CreateChatThreadResult createChatThreadResult = chatClient.CreateChatThread("", new List<ChatParticipant>() { chatParticipant });

            //assert
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(createChatThreadResult.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");

            Assert.AreEqual(3, createChatThreadResult.InvalidParticipants.Count);
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
            AsssertParticipantError(addChatParticipantsResult.InvalidParticipants.First(x => x.Code == "401"), "Authentication failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345678");
            AsssertParticipantError(addChatParticipantsResult.InvalidParticipants.First(x => x.Code == "403"), "Permissions check failed", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345679");
            AsssertParticipantError(addChatParticipantsResult.InvalidParticipants.First(x => x.Code == "404"), "Not found", "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-1234-1234-1234-223a12345677");
            Assert.AreEqual(3, addChatParticipantsResult.InvalidParticipants.Count);
        }

        [Test]
        public async Task AddParticipantFailureShouldThrowError()
        {
            //arrange
            var id = "8:acs:1b5cc06b-f352-4571-b1e6-d9b259b7c776_00000007-0464-274b-b274-5a3a0d000101";
            ChatParticipant chatParticipant = new ChatParticipant(new CommunicationUserIdentifier(id));
            ChatThreadClient chatThreadClient = CreateMockChatThreadClient(401);
            try
            {
                //act
                await chatThreadClient.AddParticipantAsync(chatParticipant);
            }
            catch (RequestFailedException requestFailedException)
            {
                //assert
                Assert.AreEqual(401, requestFailedException.Status);
            }
        }

        [Test]
        public void TestMockingModels()
        {
            var chatThreadProperties = ChatModelFactory.ChatThreadProperties("id", "topic", It.IsAny<DateTimeOffset>(), It.IsAny<CommunicationIdentifier>(), It.IsAny<DateTimeOffset>());
            Assert.IsNotNull(chatThreadProperties);

            var createChatThreadResult = ChatModelFactory.CreateChatThreadResult(chatThreadProperties, It.IsAny<IEnumerable<ChatError>>());
            Assert.IsNotNull(createChatThreadResult);

            var sendChatMessageResult = ChatModelFactory.SendChatMessageResult("id");
            Assert.IsNotNull(sendChatMessageResult);

            var innerChatError = new ChatError("innerErrorCode", "InnerCodeMessage");
            var chatErrorDetails = new List<ChatError>() { new ChatError("detailsErrorCode", "DetailsCodeMessage") };
            var chatError = ChatModelFactory.ChatError("code", "message", "target", chatErrorDetails, innerChatError);
            Assert.IsNotNull(chatError);
            Assert.AreEqual(chatError.Details, chatErrorDetails);
            Assert.AreEqual(chatError.InnerError, innerChatError);

            var chatParticipant = ChatModelFactory.ChatParticipant(It.IsAny<CommunicationIdentifier>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<IDictionary<string, string>>());
            Assert.IsNotNull(chatParticipant);

            var addChatParticipantsResult = ChatModelFactory.AddChatParticipantsResult(It.IsAny<IEnumerable<ChatError>>());
            Assert.IsNotNull(addChatParticipantsResult);

            var addChatParticipantsResultEmpty = new AddChatParticipantsResult();
            Assert.IsNotNull(addChatParticipantsResultEmpty);

            var chatThreadItem = ChatModelFactory.ChatThreadItem("id", "topic", It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>());
            Assert.IsNotNull(chatThreadItem);

            var chatMessageContent = ChatModelFactory.ChatMessageContent("id", "topic", It.IsAny<CommunicationUserIdentifier>(), It.IsAny<IEnumerable<ChatParticipant>>(), It.IsAny<IReadOnlyList<ChatAttachment>>());
            Assert.IsNotNull(chatMessageContent);

            try
            {
                var chatMessage = ChatModelFactory.ChatMessage("id", It.IsAny<ChatMessageType>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ChatMessageContent>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<string>(), It.IsAny<DateTimeOffset>(), It.IsAny<DateTimeOffset>(), It.IsAny<IReadOnlyDictionary<string, string>>());
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }

            var chatMessageReceipt = ChatModelFactory.ChatMessageReadReceipt(It.IsAny<CommunicationUserIdentifier>(), "messageId", It.IsAny<DateTimeOffset>());
            Assert.IsNotNull(chatMessageReceipt);
        }

        [Test]
        public void TestChatClientOptions()
        {
            var options = new ChatClientOptions(ChatClientOptions.ServiceVersion.V2021_09_07);
            Assert.IsNotNull(options);
        }

        private void AsssertParticipantError(ChatError chatParticipantError, string expectedMessage, string expectedTarget)
        {
            Assert.AreEqual(expectedMessage, chatParticipantError.Message);
            Assert.AreEqual(expectedTarget, chatParticipantError.Target);
        }

        private ChatClient CreateMockChatClient(int responseCode, string? responseContent = null)
        {
            var uri = new Uri("https://localHostTest");
            var communicationTokenCredential = new CommunicationTokenCredential(ChatLiveTestBase.SanitizedUnsignedUserTokenValue);
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
