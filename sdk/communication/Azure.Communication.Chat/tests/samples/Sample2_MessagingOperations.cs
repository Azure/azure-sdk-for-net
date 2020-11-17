﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Administration;
using Azure.Communication.Administration.Models;
using Azure.Communication.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Chat.Tests.samples
{
    public partial class Sample2_MessagingOperations : SamplesBase<ChatTestEnvironment>
    {
        // This sample demonstrates the messaging operations that can be performed on a thread: send, get, update, delete, typing notifications and readreceipts
        [Test]
        public async Task SendGetUpdateDeleteMessagesSendNotificationReadReceiptsAsync()
        {
            CommunicationIdentityClient communicationIdentityClient = new CommunicationIdentityClient(TestEnvironment.ConnectionString);
            Response<CommunicationUser> threadMember = await communicationIdentityClient.CreateUserAsync();
            CommunicationUserToken communicationUserToken = await communicationIdentityClient.IssueTokenAsync(threadMember.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;
            string endpoint = TestEnvironment.ChatApiUrl();
            string theadCreatorMemberId = communicationUserToken.User.Id;

            ChatClient chatClient = new ChatClient(
                new Uri(endpoint),
                new CommunicationUserCredential(userToken));

            var chatParticipant = new ChatParticipant(new CommunicationUser(theadCreatorMemberId))
            {
                DisplayName = "UserDisplayName",
                ShareHistoryTime = DateTime.MinValue
            };
            ChatThreadClient chatThreadClient = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant });
            string threadId = chatThreadClient.Id;

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage
            var content = "hello world";
            var priority = ChatMessagePriority.Normal;
            var senderDisplayName = "sender name";
            var messageId = await chatThreadClient.SendMessageAsync(content, priority, senderDisplayName);
            #endregion Snippet:Azure_Communication_Chat_Tests_SendMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage
            ChatMessage chatMessage = await chatThreadClient.GetMessageAsync(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages
            AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();
            await foreach (ChatMessage message in allMessages)
            {
                Console.WriteLine($"{message.Id}:{message.Sender.Id}:{message.Content}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages

            #region Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage
            await chatThreadClient.UpdateMessageAsync(messageId, "updated message content");
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_UpdateMessage

            //Note : Due to the async nature of the storage, moving coverage to CI tests
            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt
            //@@await chatThreadClient.SendReadReceiptAsync(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendReadReceipt

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts
            AsyncPageable<ChatMessageReadReceipt> allReadReceipts = chatThreadClient.GetReadReceiptsAsync();
            await foreach (ChatMessageReadReceipt readReceipt in allReadReceipts)
            {
                Console.WriteLine($"{readReceipt.ChatMessageId}:{readReceipt.Sender.Id}:{readReceipt.ReadOn}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage
            await chatThreadClient.DeleteMessageAsync(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification
            await chatThreadClient.SendTypingNotificationAsync();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification

            await chatClient.DeleteChatThreadAsync(threadId);
        }
    }
}
