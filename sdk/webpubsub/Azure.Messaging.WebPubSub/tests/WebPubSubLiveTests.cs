// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.WebPubSub;

using NUnit.Framework;

namespace Azure.Rest.WebPubSub.Tests
{
    public class WebPubSubLiveTests : RecordedTestBase<WebPubSubTestEnvironment>
    {
        public WebPubSubLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        [Ignore("Ignore until live test is supported")]
        [Test]
        public async Task SimpleWebSocketClientCanConnectAndReceiveMessage()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());

            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(SimpleWebSocketClientCanConnectAndReceiveMessage), options);

            var url = await serviceClient.GetClientAccessUriAsync();
            // start the connection
            using var client = new WebSocketClient(url, IsSimpleClientEndSignal);

            // connected
            await client.WaitForConnected.OrTimeout();

            // broadcast messages

            var textContent = "Hello";
            await serviceClient.SendToAllAsync(textContent, ContentType.TextPlain);
            var jsonContent = BinaryData.FromObjectAsJson(new { hello = "world" });
            await serviceClient.SendToAllAsync(RequestContent.Create(jsonContent), ContentType.ApplicationJson);
            var binaryContent = BinaryData.FromString("Hello");
            await serviceClient.SendToAllAsync(RequestContent.Create(binaryContent), ContentType.ApplicationOctetStream);

            await serviceClient.SendToAllAsync(RequestContent.Create(GetEndSignalBytes()), ContentType.ApplicationOctetStream);

            await client.LifetimeTask.OrTimeout();
            var frames = client.ReceivedFrames;

            Assert.AreEqual(3, frames.Count);
            Assert.AreEqual(textContent, frames[0].MessageAsString);
            Assert.AreEqual(jsonContent.ToString(), frames[1].MessageAsString);
            CollectionAssert.AreEquivalent(binaryContent.ToArray(), frames[2].MessageBytes);
        }

        [Ignore("Ignore until live test is supported")]
        [Test]
        public async Task WebSocketClientWithIntialGroupCanConnectAndReceiveGroupMessages()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());

            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(WebSocketClientWithIntialGroupCanConnectAndReceiveGroupMessages), options);

            var group = "GroupA";
            var url = await serviceClient.GetClientAccessUriAsync(groups: new string[] { group });
            // start the connection
            using var client = new WebSocketClient(url, IsSimpleClientEndSignal);

            // connected
            await client.WaitForConnected.OrTimeout();

            // broadcast messages

            var textContent = "Hello";
            await serviceClient.SendToGroupAsync(group, textContent, ContentType.TextPlain);
            var jsonContent = BinaryData.FromObjectAsJson(new { hello = "world" });
            await serviceClient.SendToGroupAsync(group, RequestContent.Create(jsonContent), ContentType.ApplicationJson);
            var binaryContent = BinaryData.FromString("Hello");
            await serviceClient.SendToGroupAsync(group, RequestContent.Create(binaryContent), ContentType.ApplicationOctetStream);

            await serviceClient.SendToGroupAsync(group, RequestContent.Create(GetEndSignalBytes()), ContentType.ApplicationOctetStream);

            await client.LifetimeTask.OrTimeout();
            var frames = client.ReceivedFrames;

            Assert.AreEqual(3, frames.Count);
            Assert.AreEqual(textContent, frames[0].MessageAsString);
            Assert.AreEqual(jsonContent.ToString(), frames[1].MessageAsString);
            CollectionAssert.AreEquivalent(binaryContent.ToArray(), frames[2].MessageBytes);
        }

        [Ignore("Ignore until live test is supported")]
        [Test]
        public async Task SubprotocolWebSocketClientCanConnectAndReceiveMessage()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());

            var serviceClient = new WebPubSubServiceClient(TestEnvironment.ConnectionString, nameof(SubprotocolWebSocketClientCanConnectAndReceiveMessage), options);

            var url = await serviceClient.GetClientAccessUriAsync();
            // start the connection
            using var client = new WebSocketClient(url, IsSubprotocolClientEndSignal, a => a.AddSubProtocol("json.webpubsub.azure.v1"));

            // connected
            await client.WaitForConnected.OrTimeout();

            // broadcast messages

            var textContent = "Hello";
            await serviceClient.SendToAllAsync(textContent, ContentType.TextPlain);
            var jsonContent = new { hello = "world" };
            await serviceClient.SendToAllAsync(RequestContent.Create(BinaryData.FromObjectAsJson(jsonContent)), ContentType.ApplicationJson);
            var binaryContent = BinaryData.FromString("Hello");
            await serviceClient.SendToAllAsync(RequestContent.Create(binaryContent), ContentType.ApplicationOctetStream);

            await serviceClient.SendToAllAsync(RequestContent.Create(GetEndSignalBytes()), ContentType.ApplicationOctetStream);

            await client.LifetimeTask.OrTimeout();
            var frames = client.ReceivedFrames;

            Assert.AreEqual(4, frames.Count);
            // first message must be the "connected" message
            var connected = JsonSerializer.Deserialize<ConnectedMessage>(frames[0].MessageAsString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            Assert.NotNull(connected);
            Assert.AreEqual("connected", connected.Event);
            Assert.AreEqual(JsonSerializer.Serialize(new {
                type = "message",
                from = "server",
                dataType = "text",
                data = textContent
            }), frames[1].MessageAsString);
            Assert.AreEqual(JsonSerializer.Serialize(new
            {
                type = "message",
                from = "server",
                dataType = "json",
                data = jsonContent
            }), frames[2].MessageAsString);
            CollectionAssert.AreEquivalent(JsonSerializer.Serialize(new
            {
                type = "message",
                from = "server",
                dataType = "binary",
                data = Convert.ToBase64String(binaryContent.ToArray())
            }), frames[3].MessageBytes);
        }

        private sealed class ConnectedMessage
        {
            public string Type { get; set; }
            public string Event { get; set; }
            public string UserId { get; set; }
            public string ConnectionId { get; set; }
        }

        private static bool IsSimpleClientEndSignal(WebSocketFrame frame)
        {
            var bytes = frame.MessageBytes;
            return bytes.Length == 3 && bytes[0] == 5 && bytes[1] == 1 && bytes[2] == 1;
        }

        private static bool IsSubprotocolClientEndSignal(WebSocketFrame frame)
        {
            return frame.MessageAsString == JsonSerializer.Serialize(new
            {
                type = "message",
                from = "server",
                dataType = "binary",
                data = "BQEB"
            });
        }

        private static byte[] GetEndSignalBytes()
        {
            return new byte[] { 5, 1, 1 };
        }

        private sealed class WebSocketFrame
        {
            public string MessageAsString { get; }

            public byte[] MessageBytes { get; }

            public WebSocketMessageType MessageType { get; }

            public WebSocketFrame(byte[] bytes, WebSocketMessageType type)
            {
                switch (type)
                {
                    case WebSocketMessageType.Text:
                        MessageBytes = bytes;
                        MessageAsString = Encoding.UTF8.GetString(bytes);
                        break;
                    case WebSocketMessageType.Binary:
                        MessageBytes = bytes;
                        MessageAsString = null;
                        break;
                    default:
                        throw new NotSupportedException(type.ToString());
                }
            }
        }

        private sealed class WebSocketClient : IDisposable
        {
            private readonly ClientWebSocket _webSocket;
            private readonly Uri _uri;
            private readonly Func<WebSocketFrame, bool> _isEndSignal;

            public Task LifetimeTask { get; }
            public Task WaitForConnected { get; }

            public List<WebSocketFrame> ReceivedFrames { get; } = new List<WebSocketFrame>();

            public WebSocketClient(Uri uri, Func<WebSocketFrame, bool> isEndSignal, Action<ClientWebSocketOptions> configureOptions = null)
            {
                _uri = uri;
                _isEndSignal = isEndSignal;
                var ws = new ClientWebSocket();
                configureOptions?.Invoke(ws.Options);

                _webSocket = ws;
                WaitForConnected = ConnectAsync();
                LifetimeTask = ReceiveLoop(default);
            }

            public void Dispose()
            {
                _webSocket.Abort();
            }

            public async Task StopAsync()
            {
                try
                {
                    // Block a Start from happening until we've finished capturing the connection state.
                    await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", default);
                }
                catch { }
                // Wait for the receiving tast to end
                await LifetimeTask;
            }

            public Task SendAsync(ArraySegment<byte> binaryMessage, WebSocketMessageType messageType, bool endOfMessage, CancellationToken token)
            {
                return _webSocket.SendAsync(binaryMessage, messageType, endOfMessage, token);
            }

            private Task ConnectAsync()
            {
                return _webSocket.ConnectAsync(_uri, default);
            }

            private async Task ReceiveLoop(CancellationToken token)
            {
                await WaitForConnected;
                var ms = new MemoryStream();
                var buffer = new byte[1024];
                while (!token.IsCancellationRequested)
                {
                    var segments = new ArraySegment<byte>(buffer);
                    var receiveResult = await _webSocket.ReceiveAsync(segments, token);

                    if (receiveResult.MessageType == WebSocketMessageType.Close)
                    {
                        try
                        {
                            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, default);
                        }
                        catch
                        {
                            // It is possible that the remote is already closed
                        }
                        return;
                    }

                    await ms.WriteAsync(buffer, segments.Offset, receiveResult.Count);
                    if (receiveResult.EndOfMessage)
                    {
                        var frame = new WebSocketFrame(ms.ToArray(), receiveResult.MessageType);
                        if (_isEndSignal(frame))
                        {
                            break;
                        }
                        else
                        {
                            ReceivedFrames.Add(frame);
                            ms.SetLength(0);
                        }
                    }
                }
            }
        }
    }
}
