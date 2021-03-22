// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Communication.Identity;
using Azure.Core;
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
            Response<CommunicationUserIdentifier> threadMember = await communicationIdentityClient.CreateUserAsync();
            AccessToken communicationUserToken = await communicationIdentityClient.GetTokenAsync(threadMember.Value, new[] { CommunicationTokenScope.Chat });
            string userToken = communicationUserToken.Token;
            string theadCreatorMemberId = threadMember.Value.Id;

            ChatClient chatClient = new ChatClient(
                TestEnvironment.Endpoint,
                new CommunicationTokenCredential(userToken));

            var chatParticipant = new ChatParticipant(new CommunicationUserIdentifier(theadCreatorMemberId))
            {
                DisplayName = "UserDisplayName",
                ShareHistoryTime = DateTimeOffset.MinValue
            };
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant });
            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(createChatThreadResult.ChatThread.Id);

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendMessage
            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(content:"hello world");
            var messageId = sendChatMessageResult.Id;
            #endregion Snippet:Azure_Communication_Chat_Tests_SendMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage
            ChatMessage chatMessage = await chatThreadClient.GetMessageAsync(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_GetMessages
            AsyncPageable<ChatMessage> allMessages = chatThreadClient.GetMessagesAsync();
            await foreach (ChatMessage message in allMessages)
            {
                Console.WriteLine($"{message.Id}:{message.Content.Message}");
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
                Console.WriteLine($"{readReceipt.ChatMessageId}:{((CommunicationUserIdentifier)readReceipt.Sender).Id}:{readReceipt.ReadOn}");
            }
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_GetReadReceipts

            #region Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage
            await chatThreadClient.DeleteMessageAsync(messageId);
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_DeleteMessage

            #region Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification
            await chatThreadClient.SendTypingNotificationAsync();
            #endregion Snippet:Azure_Communication_Chat_Tests_Samples_SendTypingNotification

            await chatClient.DeleteChatThreadAsync(chatThreadClient.Id);
        }
    }
}
