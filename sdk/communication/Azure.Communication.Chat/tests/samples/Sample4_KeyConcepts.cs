// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
#region Snippet:Azure_Communication_Chat_Tests_Samples_UsingStatements
using Azure.Communication.Identity;
//@@ using Azure.Communication.Chat;
#endregion Snippet:Azure_Communication_Chat_Tests_Samples_UsingStatements
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample4_KeyConcepts : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the operations that can be performed on a thread: create, get, getThreads, update and delete.
        [Test]
        public async Task Threads_Async()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> threadCreatorIdentifier = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadCreatorIdentifier.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;

            ChatClient chatClient = new ChatClient(
                TestEnvironment.Endpoint,
                new CommunicationTokenCredential(userToken));

            #region Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread_KeyConcepts
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new ChatParticipant[] { });
            ChatThread chatThread = createChatThreadResult.ChatThread;
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_CreateThread_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadClient_KeyConcepts
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(chatThread.Id);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadClient_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread_KeyConcepts
            chatThreadClient.UpdateTopic(topic: "Launch meeting");
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_UpdateThread_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThread_KeyConcepts
            //@@ChatThread chatThread = chatClient.GetChatThread(chatThread.Id);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThread_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadsInfo_KeyConcepts
            Pageable<ChatThreadInfo> threads = chatClient.GetChatThreadsInfo();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetChatThreadsInfo_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread_KeyConcepts
            chatClient.DeleteChatThread(chatThread.Id);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteThread_KeyConcepts
        }

        [Test]
        public async Task MessagesNotificationsReadReceipts_Async()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> threadCreatorIdentifier = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadCreatorIdentifier.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;

            ChatClient chatClient = new ChatClient(
                TestEnvironment.Endpoint,
                new CommunicationTokenCredential(userToken));

            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new ChatParticipant[] { });
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(createChatThreadResult.ChatThread.Id);

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage_KeyConcepts
            string messageId = chatThreadClient.SendMessage("Let's meet at 11am");
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage_KeyConcepts
            ChatMessage message = chatThreadClient.GetMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages_KeyConcepts
            Pageable<ChatMessage> messages = chatThreadClient.GetMessages();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage_KeyConcepts
            chatThreadClient.UpdateMessage(messageId, content: "Instead of 11am, let's meet at 2pm");
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage_KeyConcepts
            chatThreadClient.DeleteMessage(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt_KeyConcepts
            chatThreadClient.SendReadReceipt(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts_KeyConcepts
            Pageable<ChatMessageReadReceipt> readReceipts = chatThreadClient.GetReadReceipts();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification_KeyConcepts
            chatThreadClient.SendTypingNotification();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification_KeyConcepts
        }

        [Test]
        public async Task Participants_Async()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUserIdentifier> threadCreatorIdentifier = await communicationIdentityClient.CreateUserAsync();
            Response<CommunicationUserIdentifier> participantIdentifier = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadCreatorIdentifier.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;

            ChatClient chatClient = new ChatClient(
                TestEnvironment.Endpoint,
                new CommunicationTokenCredential(userToken));

            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new ChatParticipant[] { });
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(createChatThreadResult.ChatThread.Id);

            #region Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants_KeyConcepts
            chatThreadClient.AddParticipants(participants: new[] { new ChatParticipant(participantIdentifier) });
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_AddParticipants_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants_KeyConcepts
            Pageable<ChatParticipant> chatParticipants = chatThreadClient.GetParticipants();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetParticipants_KeyConcepts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant_KeyConcepts
            chatThreadClient.RemoveParticipant(identifier: participantIdentifier);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_RemoveParticipant_KeyConcepts
        }
    }
}
