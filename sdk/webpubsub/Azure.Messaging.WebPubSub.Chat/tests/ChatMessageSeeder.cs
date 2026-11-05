// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Chat.Tests
{
    internal static class ChatMessageSeeder
    {
        private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(30);

        public static async Task SendTextMessageAsync(
            Uri clientAccessUri,
            string conversationId,
            string content,
            CancellationToken cancellationToken = default)
        {
            string loginInvocationId = Guid.NewGuid().ToString();
            string sendInvocationId = Guid.NewGuid().ToString();
            string loginFrame = JsonSerializer.Serialize(new
            {
                type = "invoke",
                invocationId = loginInvocationId,
                target = "event",
                @event = "chat.login",
                dataType = "text",
                data = string.Empty
            });
            string sendFrame = JsonSerializer.Serialize(new
            {
                type = "invoke",
                invocationId = sendInvocationId,
                target = "event",
                @event = "chat.sendTextMessage",
                dataType = "json",
                data = new
                {
                    conversation = new { conversationId },
                    content
                }
            });

            using var timeout = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeout.CancelAfter(Timeout);

            using var socket = new ClientWebSocket();
            socket.Options.AddSubProtocol("json.webpubsub.azure.v1");
            await socket.ConnectAsync(clientAccessUri, timeout.Token).ConfigureAwait(false);

            bool loginSent = false;
            while (socket.State == WebSocketState.Open)
            {
                string frame = await ReceiveTextFrameAsync(socket, timeout.Token).ConfigureAwait(false);
                using JsonDocument document = JsonDocument.Parse(frame);
                JsonElement root = document.RootElement;

                if (!loginSent && IsConnectedEvent(root))
                {
                    await SendTextFrameAsync(socket, loginFrame, timeout.Token).ConfigureAwait(false);
                    loginSent = true;
                    continue;
                }

                if (!root.TryGetProperty("invocationId", out JsonElement invocationId))
                {
                    continue;
                }

                string id = invocationId.GetString();
                if (id != loginInvocationId && id != sendInvocationId)
                {
                    continue;
                }

                if (!root.TryGetProperty("success", out JsonElement success) || !success.GetBoolean())
                {
                    throw new InvalidOperationException($"Chat invocation failed: {frame}");
                }

                if (id == loginInvocationId)
                {
                    await SendTextFrameAsync(socket, sendFrame, timeout.Token).ConfigureAwait(false);
                }
                else
                {
                    return;
                }
            }

            throw new InvalidOperationException("The Web PubSub connection closed before the chat message was sent.");
        }

        private static bool IsConnectedEvent(JsonElement root) =>
            root.TryGetProperty("type", out JsonElement type) && type.GetString() == "system" &&
            root.TryGetProperty("event", out JsonElement eventName) && eventName.GetString() == "connected";

        private static async Task SendTextFrameAsync(ClientWebSocket socket, string frame, CancellationToken cancellationToken)
        {
            byte[] payload = Encoding.UTF8.GetBytes(frame);
            await socket.SendAsync(new ArraySegment<byte>(payload), WebSocketMessageType.Text, true, cancellationToken).ConfigureAwait(false);
        }

        private static async Task<string> ReceiveTextFrameAsync(ClientWebSocket socket, CancellationToken cancellationToken)
        {
            byte[] buffer = new byte[4096];
            using var stream = new MemoryStream();

            WebSocketReceiveResult result;
            do
            {
                result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(false);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    throw new InvalidOperationException("The Web PubSub connection closed unexpectedly.");
                }
                stream.Write(buffer, 0, result.Count);
            }
            while (!result.EndOfMessage);

            if (result.MessageType != WebSocketMessageType.Text)
            {
                throw new InvalidOperationException("The Web PubSub connection returned a non-text frame.");
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}