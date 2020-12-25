// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.ChatClients
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class ChatClientsTests : ClientTestBase
    {
        private const string _allMessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"1\",\"content\":\"Content for async message 1\",\"senderDisplayName\":\"Display Name for async  message 1\",\"createdOn\":\"2020-11-05T01:44:24Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"2\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"2\",\"content\":\"Content for async message 2\",\"senderDisplayName\":\"Display Name for async  message 2\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"3\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"3\",\"content\":\"Content for async message 3\",\"senderDisplayName\":\"Display Name for async  message 3\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"4\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"4\",\"content\":\"Content for async message 4\",\"senderDisplayName\":\"Display Name for async  message 4\",\"createdOn\":\"2020-11-05T01:44:22Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"5\",\"type\":\"Text\",\"priority\":\"Normal\",\"version\":\"5\",\"content\":\"Content for async message 5\",\"senderDisplayName\":\"Display Name for async  message 5\",\"createdOn\":\"2020-11-05T01:44:21Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f\"},{\"id\":\"6\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"6\",\"content\":\"<topicupdate><eventtime>1604540653896</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Updated topic - C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"7\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"7\",\"content\":\"<topicupdate><eventtime>1604540653340</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Thread async from C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"8\",\"type\":\"ThreadActivity/AddMember\",\"priority\":\"Normal\",\"version\":\"8\",\"content\":\"<addmember><eventtime>1604540653315</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><rosterVersion>1604540653270</rosterVersion><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</id></detailedtargetinfo></addmember>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"}]}";
        private const string _page1MessagesApiResponsePayload = "{\"value\":[{\"id\":\"1\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"1\",\"content\":\"Content for async message 1\",\"senderDisplayName\":\"Display Name for async  message 1\",\"createdOn\":\"2020-11-05T01:44:24Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"2\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"2\",\"content\":\"Content for async message 2\",\"senderDisplayName\":\"Display Name for async  message 2\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"3\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"3\",\"content\":\"Content for async message 3\",\"senderDisplayName\":\"Display Name for async  message 3\",\"createdOn\":\"2020-11-05T01:44:23Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"},{\"id\":\"4\",\"type\":\"Text\",\"priority\":\"High\",\"version\":\"4\",\"content\":\"Content for async message 4\",\"senderDisplayName\":\"Display Name for async  message 4\",\"createdOn\":\"2020-11-05T01:44:22Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451\"}],\"nextLink\":\"nextLink\"}";
        private const string _page2MessagesApiResponsePayload = "{\"value\":[{\"id\":\"5\",\"type\":\"Text\",\"priority\":\"Normal\",\"version\":\"5\",\"content\":\"Content for async message 5\",\"senderDisplayName\":\"Display Name for async  message 5\",\"createdOn\":\"2020-11-05T01:44:21Z\",\"senderId\":\"8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f\"},{\"id\":\"6\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"6\",\"content\":\"<topicupdate><eventtime>1604540653896</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Updated topic - C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"7\",\"type\":\"ThreadActivity/TopicUpdate\",\"priority\":\"Normal\",\"version\":\"7\",\"content\":\"<topicupdate><eventtime>1604540653340</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><value>Thread async from C# sdk</value></topicupdate>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"},{\"id\":\"8\",\"type\":\"ThreadActivity/AddMember\",\"priority\":\"Normal\",\"version\":\"8\",\"content\":\"<addmember><eventtime>1604540653315</eventtime><initiator>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</initiator><rosterVersion>1604540653270</rosterVersion><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-f7de-68ab-1c482200044f</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-faef-68ab-1c4822000450</id></detailedtargetinfo><target>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</target><detailedtargetinfo><id>8:acs:fa5c4fc3-a269-43e2-9eb6-0ca17b388993_00000006-35f4-fd8a-68ab-1c4822000451</id></detailedtargetinfo></addmember>\",\"createdOn\":\"2020-11-05T01:44:13Z\",\"senderId\":\"19:77cb1b9855764965ac7cb194277de44d@thread.v2\"}]}";
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
            responseAllItems.SetContent(_allMessagesApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseAllItems)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatThreadClient = new ChatThreadClient(threadId, uri, communicationTokenCredential, chatClientOptions);
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
            responseItemsPage1.SetContent(_page1MessagesApiResponsePayload);

            var responseItemsPage2 = new MockResponse(200);
            responseItemsPage2.SetContent(_page2MessagesApiResponsePayload);

            var chatClientOptions = new ChatClientOptions
            {
                Transport = new MockTransport(responseItemsPage1, responseItemsPage2)
            };

            //act
            var communicationTokenCredential = new CommunicationTokenCredential(ChatRecordedTestSanitizer.SanitizedUnsignedUserTokenValue);
            var chatThreadClient = new ChatThreadClient(threadId, uri, communicationTokenCredential, chatClientOptions);
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
    }
}
