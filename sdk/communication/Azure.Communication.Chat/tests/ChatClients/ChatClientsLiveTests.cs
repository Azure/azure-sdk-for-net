// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
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
        [Test]
        public async Task Thread_CGUD__Participant_AUR__Message_GSU__Notification_T()
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

            var participant1 = new ChatParticipant(user1) { DisplayName = "user1" };
            participant1.Metadata.Add("ParticipantMetaKey1", "ParticipantMetaValue1");
            participant1.Metadata.Add("ParticipantMetaKey2", "ParticipantMetaValue2");
            ChatClient chatClient = CreateInstrumentedChatClient(token1);
            ChatClient chatClient3 = CreateInstrumentedChatClient(token3);

            var options = new CreateChatThreadOptions(topic);
            options.Metadata.Add("MetaKey1", "MetaValue1");
            options.Metadata.Add("MetaKey2", "MetaValue2");
            options.IdempotencyToken = repeatabilityRequestId1;
            options.Participants.Add(participant1);
            options.Participants.Add(new ChatParticipant(user2) { DisplayName = "user2" });
            options.Participants.Add(new ChatParticipant(user3) { DisplayName = "user3" });
            options.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(60);

            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(options);

            //act
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult.ChatThread.Id);
            var threadId = chatThreadClient.Id;

            Assert.IsNotNull(createChatThreadResult.ChatThread.Metadata);
            Assert.AreEqual("MetaValue1", createChatThreadResult.ChatThread.Metadata["MetaKey1"]);
            Assert.AreEqual("MetaValue2", createChatThreadResult.ChatThread.Metadata["MetaKey2"]);

            Assert.IsNotNull(createChatThreadResult.ChatThread.RetentionPolicy);
            var threadCreationDateRetentionPolicy = createChatThreadResult.ChatThread.RetentionPolicy as ThreadCreationDateRetentionPolicy;
            Assert.IsNotNull(threadCreationDateRetentionPolicy);
            Assert.AreEqual(RetentionPolicyKind.ThreadCreationDate, threadCreationDateRetentionPolicy?.Kind);
            Assert.AreEqual(60, threadCreationDateRetentionPolicy?.DeleteThreadAfterDays);

            var participants = new List<ChatParticipant>
            {
                new ChatParticipant(user1) { DisplayName = "user1" },
                new ChatParticipant(user2) { DisplayName = "user2" },
                new ChatParticipant(user3) { DisplayName = "user3" }
            };
            CreateChatThreadResult createChatThreadResult2 = await chatClient.CreateChatThreadAsync(topic, participants, repeatabilityRequestId2);
            ChatThreadClient chatThreadClient2 = GetInstrumentedChatThreadClient(chatClient, createChatThreadResult2.ChatThread.Id);
            ChatThreadClient chatThreadClient3 = GetInstrumentedChatThreadClient(chatClient3, threadId);

            AsyncPageable<ChatParticipant> chatParticipantsOnCreation = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsOnCreationList = chatParticipantsOnCreation.ToEnumerableAsync().Result;
            var chatParticipantsOnCreationCount = chatParticipantsOnCreationList.Count;

            var chatParticipant1 = chatParticipantsOnCreationList.FirstOrDefault(x => x.User == user1);
            Assert.AreEqual("ParticipantMetaValue1", chatParticipant1?.Metadata["ParticipantMetaKey1"]);
            Assert.AreEqual("ParticipantMetaValue2", chatParticipant1?.Metadata["ParticipantMetaKey2"]);

            var updatedTopic = "Updated topic - C# sdk";
            await chatThreadClient.UpdateTopicAsync(updatedTopic);
            ChatThreadProperties chatThread = await chatThreadClient.GetPropertiesAsync();

            string messageContent = "Content for message 1";
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(messageContent, ChatMessageType.Text, displayNameMessage);
            string messageId = sendChatMessageResult.Id;

            string messageContent2 = "Content for message 2";
            SendChatMessageResult sendChatMessageResult2 = await chatThreadClient2.SendMessageAsync(messageContent2, ChatMessageType.Html, displayNameMessage);
            string messageId2 = sendChatMessageResult2.Id;

            string messageContent3 = "Content for message 3";
            SendChatMessageResult sendChatMessageResult3 = await chatThreadClient3.SendMessageAsync(messageContent3, ChatMessageType.Text, displayNameMessage);
            string messageId3 = sendChatMessageResult3.Id;

            string messageContent4 = "Content for message 4";
            SendChatMessageResult sendChatMessageResult4 = await chatThreadClient3.SendMessageAsync(messageContent4, ChatMessageType.Html, displayNameMessage);
            string messageId4 = sendChatMessageResult4.Id;

            string messageContent5 = "Content for message 5";
            SendChatMessageResult sendChatMessageResult5 = await chatThreadClient3.SendMessageAsync(messageContent5, ChatMessageType.Text, displayNameMessage);
            string messageId5 = sendChatMessageResult5.Id;

            string messageContent6 = "Content for message 6";
            SendChatMessageResult sendChatMessageResult6 = await chatThreadClient3.SendMessageAsync(messageContent6, ChatMessageType.Html, displayNameMessage);
            string messageId6 = sendChatMessageResult6.Id;

            SendChatMessageOptions sendChatMessageOptions7 = new()
            {
                Content = "Content for message 7",
                MessageType = ChatMessageType.Html,
                SenderDisplayName = "DisplayName sender message options message 7",
                Metadata = {
                    { "tags", "tag value" },
                    { "deliveryMode", "deliveryMode value" },
                    { "onedriveReferences", "onedriveReferences value" },
                    { "amsreferences", "[\"test url file 1\",\"test url file2\"]" },
                    { "key", "value key" }
                }
            };
            SendChatMessageResult sendChatMessageResult7 = await chatThreadClient3.SendMessageAsync(sendChatMessageOptions7);
            string messageId7 = sendChatMessageResult7.Id;

            ChatMessage message = await chatThreadClient.GetMessageAsync(messageId);
            ChatMessage message2 = await chatThreadClient2.GetMessageAsync(messageId2);
            ChatMessage message3 = await chatThreadClient3.GetMessageAsync(messageId3);
            ChatMessage message4 = await chatThreadClient3.GetMessageAsync(messageId4);
            ChatMessage message5 = await chatThreadClient3.GetMessageAsync(messageId5);
            ChatMessage message6 = await chatThreadClient3.GetMessageAsync(messageId6);
            ChatMessage message7 = await chatThreadClient3.GetMessageAsync(messageId7);

            AsyncPageable<ChatMessage> messages = chatThreadClient.GetMessagesAsync();
            AsyncPageable<ChatMessage> messages2 = chatThreadClient2.GetMessagesAsync();
            var getMessagesCount = messages.ToEnumerableAsync().Result.Count;
            var getMessagesCount2 = messages2.ToEnumerableAsync().Result.Count;

            #region Messages pagination assertions
            AsyncPageable<ChatMessage> messagesPaginationTest = chatThreadClient.GetMessagesAsync();
            await PageableTester<ChatMessage>.AssertPaginationAsync(enumerableResource: messagesPaginationTest, expectedPageSize: 2, expectedTotalResources: 9);
            #endregion

            //Simple content update
            var updatedMessageContent = "This is message 1 content updated";
            await chatThreadClient.UpdateMessageAsync(messageId, updatedMessageContent);
            Response<ChatMessage> actualUpdateMessage = await chatThreadClient.GetMessageAsync(messageId);

            await chatThreadClient.DeleteMessageAsync(messageId);

            //Options update
            UpdateChatMessageOptions updateChatMessageOptions7 = new()
            {
                MessageId = messageId7,
                Content = "Content for message 7 - updated",
                Metadata = {
                    { "tags", "" },
                    { "deliveryMode", "deliveryMode value - updated" },
                    { "onedriveReferences", "onedriveReferences value - updated" },
                    { "amsreferences", "[\"test url file 3\"]" },
                    { "key", "value key" }
                }
            };

            await chatThreadClient3.UpdateMessageAsync(updateChatMessageOptions7);
            Response<ChatMessage> actualUpdatedMessage7 = await chatThreadClient3.GetMessageAsync(messageId7);
            List<ChatMessage> messagesAfterOneDeleted = chatThreadClient.GetMessagesAsync().ToEnumerableAsync().Result;
            ChatMessage deletedChatMessage = messagesAfterOneDeleted.First(x => x.Id == messageId);

            #region Participants Pagination assertions
            AsyncPageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipantsAsync();
            var chatParticipantsCount = chatParticipants.ToEnumerableAsync().Result.Count;
            #endregion

            var newParticipant = new ChatParticipant(user4) { DisplayName = "user4" };
            var newParticipant2 = new ChatParticipant(user5) { DisplayName = "user5" };
            AddChatParticipantsResult addChatParticipantsResult = await chatThreadClient.AddParticipantsAsync(participants: new[] { newParticipant });
            Response addChatParticipantResult = await chatThreadClient.AddParticipantAsync(newParticipant2);

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

            TypingNotificationOptions typingNotificationOptions = new() { SenderDisplayName = "sender diplay name" };
            Response typingNotificationWithOptionsResponse = await chatThreadClient.SendTypingNotificationAsync(typingNotificationOptions);

            AsyncPageable<ChatThreadItem> threads = chatClient.GetChatThreadsAsync();
            var threadsCount = threads.ToEnumerableAsync().Result.Count;

            await chatClient.DeleteChatThreadAsync(threadId);

            //assert
            Assert.AreEqual(updatedTopic, chatThread.Topic);
            Assert.AreEqual(3, chatParticipantsOnCreationCount);
            Assert.AreEqual(messageContent, message.Content.Message);
            Assert.AreEqual(displayNameMessage, message.SenderDisplayName);
            Assert.AreEqual(updatedMessageContent, actualUpdateMessage.Value.Content.Message);
            Assert.AreEqual(ChatMessageType.Text, message.Type);

            Assert.AreEqual(ChatMessageType.Html, message2.Type);
            Assert.AreEqual(ChatMessageType.Text, message3.Type);
            Assert.AreEqual(ChatMessageType.Html, message4.Type);
            Assert.AreEqual(ChatMessageType.Text, message5.Type);
            Assert.AreEqual(ChatMessageType.Html, message6.Type);

            Assert.AreEqual(messageContent2, message2.Content.Message);
            Assert.AreEqual(messageContent3, message3.Content.Message);
            Assert.AreEqual(messageContent4, message4.Content.Message);
            Assert.AreEqual(messageContent5, message5.Content.Message);
            Assert.AreEqual(messageContent6, message6.Content.Message);

            Assert.AreEqual(sendChatMessageOptions7.MessageType, message7.Type);
            Assert.AreEqual(sendChatMessageOptions7.SenderDisplayName, message7.SenderDisplayName);
            Assert.AreEqual(sendChatMessageOptions7.Content, message7.Content.Message);
            CollectionAssert.AreEquivalent(sendChatMessageOptions7.Metadata, message7.Metadata);

            Assert.AreEqual(sendChatMessageOptions7.MessageType, actualUpdatedMessage7.Value.Type);
            Assert.AreEqual(sendChatMessageOptions7.SenderDisplayName, actualUpdatedMessage7.Value.SenderDisplayName);
            Assert.AreEqual(updateChatMessageOptions7.Content, actualUpdatedMessage7.Value.Content.Message);
            Assert.AreEqual(4, actualUpdatedMessage7.Value.Metadata.Count);
            Assert.AreEqual(updateChatMessageOptions7.Metadata["deliveryMode"], actualUpdatedMessage7.Value.Metadata["deliveryMode"]);
            Assert.AreEqual(updateChatMessageOptions7.Metadata["onedriveReferences"], actualUpdatedMessage7.Value.Metadata["onedriveReferences"]);
            Assert.AreEqual(updateChatMessageOptions7.Metadata["amsreferences"], actualUpdatedMessage7.Value.Metadata["amsreferences"]);
            Assert.AreEqual(updateChatMessageOptions7.Metadata["key"], actualUpdatedMessage7.Value.Metadata["key"]);
            Assert.AreEqual(2, threadsCount);
            Assert.AreEqual(9, getMessagesCount); //Including all types : 6 text message, 3 control messages
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
            Assert.AreEqual(0, addChatParticipantsResult.InvalidParticipants.Count);
            Assert.AreEqual((int)HttpStatusCode.Created, addChatParticipantResult.Status);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationResponse.Status);
            Assert.AreEqual((int)HttpStatusCode.OK, typingNotificationWithOptionsResponse.Status);
        }

        /// <summary>
        /// Through tests on update thread properties
        /// </summary>
        [Test]
        public async Task Update_Thread_Properties()
        {
            Console.WriteLine($"Update_Thread_Properties running on TestMode: {Mode}");

            CommunicationIdentityClient identityClient = CreateInstrumentedCommunicationIdentityClient();
            (CommunicationUserIdentifier user, string token) = await CreateUserAndTokenAsync(identityClient);
            ChatClient chatClient = CreateInstrumentedChatClient(token);

            var createOptions = new CreateChatThreadOptions("init thread");

            CreateChatThreadResult threadResult = await chatClient.CreateChatThreadAsync(createOptions);
            ChatThreadClient threadClient = GetInstrumentedChatThreadClient(chatClient, threadResult.ChatThread.Id);

            // Verify initial state
            ChatThreadProperties initialProps = await threadClient.GetPropertiesAsync();

            // Following are update thread properties tests
            ChatThreadClient chatThreadClient = GetInstrumentedChatThreadClient(chatClient, threadResult.ChatThread.Id);

            // Update properties. Only change topic.
            var updateOptionsChangeTopic = new UpdateChatThreadPropertiesOptions();
            updateOptionsChangeTopic.Topic = "updated thread topic";
            await chatThreadClient.UpdatePropertiesAsync(updateOptionsChangeTopic);

            var updateResponseUpdateTopic = await chatThreadClient.GetPropertiesAsync();
            Assert.AreEqual("updated thread topic", updateResponseUpdateTopic.Value.Topic);

            var noneRetentionPolicy = updateResponseUpdateTopic.Value.RetentionPolicy as NoneRetentionPolicy;
            Assert.IsNotNull(noneRetentionPolicy);

            // Update properties, not setting options. Topic not changed.
            var updateOptionsWithSameProperties = new UpdateChatThreadPropertiesOptions();
            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithSameProperties);

            var updateResponseWithSameProperties = await chatThreadClient.GetPropertiesAsync();
            Assert.AreEqual("updated thread topic", updateResponseWithSameProperties.Value.Topic);

            noneRetentionPolicy = updateResponseWithSameProperties.Value.RetentionPolicy as NoneRetentionPolicy;
            Assert.IsNotNull(noneRetentionPolicy);

            // Update properties adding metadata
            var updateOptionsWithNewMetadata = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNewMetadata.Topic = "Update properties adding metadata";
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew1", "MetaValueNew1");
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew2", "MetaValueNew2");

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNewMetadata);
            var updateResponseWithNewMetadata = await chatThreadClient.GetPropertiesAsync();
            Assert.AreEqual("Update properties adding metadata", updateResponseWithNewMetadata.Value.Topic);

            Assert.IsNotNull(updateResponseWithNewMetadata.Value.Metadata);
            Assert.AreEqual("MetaValueNew1", updateResponseWithNewMetadata.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueNew2", updateResponseWithNewMetadata.Value.Metadata["MetaKeyNew2"]);

            // Update properties adding retention policy deleteAfterDays
            var updateOptionsWithNewRetentionPolicy = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNewRetentionPolicy.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(40);

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNewRetentionPolicy);
            var updateResponseWithNewRetentionPolicy = await chatThreadClient.GetPropertiesAsync();
            var newDataRetentionPolicy = updateResponseWithNewRetentionPolicy.Value.RetentionPolicy as ThreadCreationDateRetentionPolicy;
            Assert.IsNotNull(newDataRetentionPolicy);
            Assert.AreEqual(RetentionPolicyKind.ThreadCreationDate, newDataRetentionPolicy?.Kind);
            Assert.AreEqual(40, newDataRetentionPolicy?.DeleteThreadAfterDays);
            Assert.IsNotNull(updateResponseWithNewRetentionPolicy.Value.Metadata);
            Assert.AreEqual("MetaValueNew1", updateResponseWithNewRetentionPolicy.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueNew2", updateResponseWithNewRetentionPolicy.Value.Metadata["MetaKeyNew2"]);

            // Update properties changing retention policy deleteAfterDays
            updateOptionsWithNewRetentionPolicy = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNewRetentionPolicy.RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(50);

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNewRetentionPolicy);
            updateResponseWithNewRetentionPolicy = await chatThreadClient.GetPropertiesAsync();
            newDataRetentionPolicy = updateResponseWithNewRetentionPolicy.Value.RetentionPolicy as ThreadCreationDateRetentionPolicy;
            Assert.IsNotNull(newDataRetentionPolicy);
            Assert.AreEqual(RetentionPolicyKind.ThreadCreationDate, newDataRetentionPolicy?.Kind);
            Assert.AreEqual(50, newDataRetentionPolicy?.DeleteThreadAfterDays);
            Assert.IsNotNull(updateResponseWithNewRetentionPolicy.Value.Metadata);
            Assert.AreEqual("MetaValueNew1", updateResponseWithNewRetentionPolicy.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueNew2", updateResponseWithNewRetentionPolicy.Value.Metadata["MetaKeyNew2"]);

            // Update properties updating tetention policy to NoneRetentionPolicy
            var updateOptionsWithNoneRetentionPolicy = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNoneRetentionPolicy.RetentionPolicy = ChatRetentionPolicy.None();

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNoneRetentionPolicy);
            var updateResponseWithNoneRetentionPolicy = await chatThreadClient.GetPropertiesAsync();
            var noneDataRetentionPolicy = updateResponseWithNoneRetentionPolicy.Value.RetentionPolicy as NoneRetentionPolicy;
            Assert.IsNotNull(noneDataRetentionPolicy);
            Assert.AreEqual(RetentionPolicyKind.None, noneDataRetentionPolicy?.Kind);

            Assert.IsNotNull(updateResponseWithNoneRetentionPolicy.Value.Metadata);
            Assert.AreEqual("MetaValueNew1", updateResponseWithNoneRetentionPolicy.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueNew2", updateResponseWithNoneRetentionPolicy.Value.Metadata["MetaKeyNew2"]);

            // Set retention policy to null and change topic
            var updateOptionsWithNullRetentionPolicyOptions = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Update properties null retention policy",
            };
            updateOptionsWithNullRetentionPolicyOptions.RetentionPolicy = null;

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNullRetentionPolicyOptions);
            var updateResponseWithNullRetentionPolicy = await chatThreadClient.GetPropertiesAsync();
            Assert.AreEqual(updateOptionsWithNullRetentionPolicyOptions.Topic, updateResponseWithNullRetentionPolicy.Value.Topic);
            var nullDataRetentionPolicy = updateResponseWithNullRetentionPolicy.Value.RetentionPolicy as NoneRetentionPolicy;
            Assert.IsNotNull(nullDataRetentionPolicy);
            Assert.AreEqual(RetentionPolicyKind.None, nullDataRetentionPolicy?.Kind);

            Assert.IsNotNull(updateResponseWithNullRetentionPolicy.Value.Metadata);
            Assert.AreEqual("MetaValueNew1", updateResponseWithNullRetentionPolicy.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueNew2", updateResponseWithNullRetentionPolicy.Value.Metadata["MetaKeyNew2"]);

            // Change values of metadata
            updateOptionsWithNewMetadata = new UpdateChatThreadPropertiesOptions();
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew1", "MetaValueChangedValue1");
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew2", "MetaValueChangedValue2");
            updateOptionsWithNewMetadata.Metadata.Add("MetaKeyNew3", "MetaValueNew3");

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithNewMetadata);
            updateResponseWithNewMetadata = await chatThreadClient.GetPropertiesAsync();
            Assert.IsNotNull(updateResponseWithNewMetadata.Value.Metadata);
            Assert.AreEqual("MetaValueChangedValue1", updateResponseWithNewMetadata.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueChangedValue2", updateResponseWithNewMetadata.Value.Metadata["MetaKeyNew2"]);
            Assert.AreEqual("MetaValueNew3", updateResponseWithNewMetadata.Value.Metadata["MetaKeyNew3"]);

            // Set metadata to empty dictionary. Previous metadata will be kept.
            var updateOptionsWithEmptyMetadata = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Update properties with empty metadata",
            };

            updateOptionsWithEmptyMetadata.Metadata.Clear();

            await chatThreadClient.UpdatePropertiesAsync(updateOptionsWithEmptyMetadata);
            var updateResponseWithEmptyMetadata = await chatThreadClient.GetPropertiesAsync();

            // Expect all previous metadata to be kept
            Assert.IsNotNull(updateResponseWithEmptyMetadata.Value.Metadata);
            Assert.AreEqual(3, updateResponseWithEmptyMetadata.Value.Metadata.Count);
            Assert.AreEqual("MetaValueChangedValue1", updateResponseWithEmptyMetadata.Value.Metadata["MetaKeyNew1"]);
            Assert.AreEqual("MetaValueChangedValue2", updateResponseWithEmptyMetadata.Value.Metadata["MetaKeyNew2"]);
            Assert.AreEqual("MetaValueNew3", updateResponseWithEmptyMetadata.Value.Metadata["MetaKeyNew3"]);

            // Update topic, metadata and retention policy in one call
            var fullUpdateOptions = new UpdateChatThreadPropertiesOptions
            {
                Topic = "Full update topic",
                RetentionPolicy = ChatRetentionPolicy.ThreadCreationDate(90)
            };
            fullUpdateOptions.Metadata.Add("KeyA", "ValueA");
            fullUpdateOptions.Metadata.Add("KeyB", "ValueB");

            await chatThreadClient.UpdatePropertiesAsync(fullUpdateOptions);
            var result = await chatThreadClient.GetPropertiesAsync();

            Assert.AreEqual("Full update topic", result.Value.Topic);
            Assert.AreEqual("ValueA", result.Value.Metadata["KeyA"]);
            Assert.AreEqual(90, ((ThreadCreationDateRetentionPolicy)result.Value.RetentionPolicy).DeleteThreadAfterDays);
        }

        [Test]
        [PlaybackOnly("Message and ReadReceipt storage uses eventual consistency. Tests to get readreceipts requires delays")]
        public async Task ReadReceipt_GS()
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

            SendChatMessageResult sendChatMessageResult2 = await chatThreadClient.SendMessageAsync("This is message 1 content");
            string messageId2 = sendChatMessageResult2.Id;

            SendChatMessageResult sendChatMessageResult = await chatThreadClient2.SendMessageAsync("This is message 2 content");
            string messageId = sendChatMessageResult.Id;

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
        private (CommunicationUserIdentifier User, string Token) CreateUserAndToken(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> user = communicationIdentityClient.CreateUser();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<AccessToken> tokenResponseUser = communicationIdentityClient.GetToken(user.Value, scopes);

            return (user, tokenResponseUser.Value.Token);
        }

        private async Task<(CommunicationUserIdentifier User, string Token)> CreateUserAndTokenAsync(CommunicationIdentityClient communicationIdentityClient)
        {
            Response<CommunicationUserIdentifier> user = await communicationIdentityClient.CreateUserAsync();
            IEnumerable<CommunicationTokenScope> scopes = new[] { CommunicationTokenScope.Chat };
            Response<AccessToken> tokenResponseUser = await communicationIdentityClient.GetTokenAsync(user.Value, scopes);

            return (user, tokenResponseUser.Value.Token);
        }

        private static class PageableTester<T> where T : notnull
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
