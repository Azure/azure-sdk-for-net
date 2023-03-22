// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.Chat.Notifications.Models;
using System.Threading.Tasks;
#pragma warning disable CS1587
#pragma warning disable CA1801 // Review unused parameters
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace Azure.Communication.Chat
{
#pragma warning disable AZC0012 // Avoid single word type names
    internal class Test
#pragma warning restore AZC0012 // Avoid single word type names
    {
        public static async Task Main(string[] args)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning restore CA1801 // Review unused parameters
        {
            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkU3RDA3MUNENkI2MkJEOEQzMjVCNjY0NTBFMzFFQ0M3OTMyREM4OTAiLCJ4NXQiOiI1OUJ4eld0aXZZMHlXMlpGRGpIc3g1TXR5SkEiLCJ0eXAiOiJKV1QifQ.eyJza3lwZWlkIjoiYWNzOjE4OGQ0Y2VhLTBhOWItNDg0MC04ZmRjLTdhNWM3MWZlOWJkMF8wMDAwMDAxNy1hMDQ5LTM5NmMtZjk5NC0wOTQ4MjIwMDExOWEiLCJzY3AiOjE3OTIsImNzaSI6IjE2NzkzMzkwMDEiLCJleHAiOjE2Nzk0MjU0MDEsInJnbiI6ImFtZXIiLCJhY3NTY29wZSI6ImNoYXQiLCJyZXNvdXJjZUlkIjoiMTg4ZDRjZWEtMGE5Yi00ODQwLThmZGMtN2E1YzcxZmU5YmQwIiwicmVzb3VyY2VMb2NhdGlvbiI6InVuaXRlZHN0YXRlcyIsImlhdCI6MTY3OTMzOTAwMX0.m6bL4vHBfvNhyFQlADf3XvsVd49vitMa6KKLC_Y-BeGM51QDEcYh7VYj88HU-6o-ALk8syfKYIKx8cn-Lh18CvdAybKps5zqYH266o0ML0eYLIRrPyz2bGaPlu0pE48d838EY27Gm_poeKuRYL_a5NvrKLAP74rTslSvYxWRZWOYuaM19nCz-yRbcfHG6jEaQdmhnmTkXVfHT9saMRYu6PqWEFFUtC_p-c9zYRIeMYakQ1HGZbTSRn1X24vCSXNACSPuRHlSuWZLToQvcJNgYWQFEdilcaoEczY1akHOPX2p_Mky-dc--UyZJqDmhTbuGdZSxQCbecPuzAItLfJdmw";

            var communicationTokenCredential = new CommunicationTokenCredential(token);

            var endpoint = new Uri("https://chat-int-runner.int.communication.azure.net/");

            var chatClient = new ChatClient(endpoint, communicationTokenCredential);

            /**
             * Starts the subscription to any real time notification event.
             * In the implementation, this starts the trouter service which listens to the real-time notifications
             **/
            await chatClient.StartRealTimeNotifications().ConfigureAwait(false);

            // Subscribe the custom implementation to the event handler.
            chatClient.ChatThreadCreated += (ChatThreadCreatedEvent e) =>
            {
                Console.WriteLine($"A Chat thread is created with id {e.ThreadId}");
                return Task.CompletedTask;
            };

            // use the `on` method to subscribe to the event.
           // chatClient.On(ChatEventType.ChatMessageReceived);

            var participantId = "8:acs:357e39d2-a29a-4bf6-88cc-fda0afc2c0ed_00000016-cf17-f42b-9a33-373a0d002072";
            var chatParticipant = new ChatParticipant(identifier: new CommunicationUserIdentifier(id: participantId));
            CreateChatThreadResult createChatThreadResult = await chatClient.CreateChatThreadAsync(topic: "Hello world!", participants: new[] { chatParticipant }).ConfigureAwait(false);

            ChatThreadClient chatThreadClient = chatClient.GetChatThreadClient(threadId: createChatThreadResult.ChatThread.Id);

            // use the `off` method to unsubscribe from the event.
            //chatClient.Off(ChatEventType.ChatMessageReceived);

            /**
              * Unsubscribe from the real-time notification feauture
              * and signals the trouter client in the implmentation to stop listening for events.
              **/
            await chatClient.StopRealTimeNotifications().ConfigureAwait(false);
            await SendChatMessage(chatThreadClient).ConfigureAwait(false);
        }

        public static async Task SendChatMessage(ChatThreadClient chatThreadClient)
        {
            SendChatMessageOptions sendChatMessageOptions = new SendChatMessageOptions()
            {
                Content = "Please take a look at the attachment",
                MessageType = ChatMessageType.Text
            };
            sendChatMessageOptions.Metadata["hasAttachment"] = "true";
            sendChatMessageOptions.Metadata["attachmentUrl"] = "https://contoso.com/files/attachment.docx";

            SendChatMessageResult sendChatMessageResult = await chatThreadClient.SendMessageAsync(sendChatMessageOptions).ConfigureAwait(false);

            string messageId = sendChatMessageResult.Id;

            Console.WriteLine($"{messageId}");
        }
    }
}
