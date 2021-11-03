// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;
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

        [Test]
        public async Task SimpleWebSocketClientCanConnectAndReceiveMessage()
        {
            WebPubSubServiceClientOptions options = InstrumentClientOptions(new WebPubSubServiceClientOptions());
            WebPubSubServiceClient serviceClient = InstrumentClient(
                new WebPubSubServiceClient(TestEnvironment.ConnectionString, "hub1", options));

            var url = await serviceClient.GetClientAccessUriAsync();
            var endTcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            List<WebSocketFrame> frames = new List<WebSocketFrame>();
            // start the connection
            using var client = new WebSocketClient(url, message =>
            {
                Console.WriteLine(message.MessageAsString);
                if (message.IsEndSignal())
                {
                    endTcs.SetResult(null);
                }
                else
                {
                    frames.Add(message);
                }
                return default;
            });

            // connected
            await client.WaitForConnected;

            // broadcast messages

            await serviceClient.SendToAllAsync("Hello", ContentType.TextPlain);
            await serviceClient.SendToAllAsync("Hello", ContentType.ApplicationJson);
            await serviceClient.SendToAllAsync("Hello", ContentType.ApplicationOctetStream);

            await serviceClient.SendToAllAsync(RequestContent.Create(WebSocketFrame.GetEndSignal()), ContentType.ApplicationOctetStream);

            await endTcs.Task;

            Assert.AreEqual(3, frames.Count);
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

            public bool IsEndSignal()
            {
                // a special byte array for end signal
                return MessageBytes.Length == 3 && MessageBytes[0] == 5 && MessageBytes[1] == 1 && MessageBytes[2] == 1;
            }

            public static byte[] GetEndSignal()
            {
                return new byte[] { 5, 1, 1 };
            }
        }

        private sealed class WebSocketClient : IDisposable
        {
            private readonly ClientWebSocket _webSocket;
            private readonly Uri _uri;
            public Func<WebSocketFrame, ValueTask> OnMessage { get; }
            public Task LifetimeTask { get; }
            public Task WaitForConnected { get; }

            public WebSocketClient(Uri uri, Func<WebSocketFrame, ValueTask> onMessage = null, Action<ClientWebSocketOptions> configureOptions = null)
            {
                _uri = uri;
                var ws = new ClientWebSocket();
                configureOptions?.Invoke(ws.Options);

                _webSocket = ws;
                WaitForConnected = ConnectAsync();
                OnMessage = onMessage;
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

                    if (OnMessage != null)
                    {
                        await ms.WriteAsync(buffer, segments.Offset, segments.Count);
                        if (receiveResult.EndOfMessage)
                        {
                            await OnMessage.Invoke(new WebSocketFrame(ms.ToArray(), receiveResult.MessageType));
                            ms.SetLength(0);
                        }
                    }
                }
            }
        }
    }
}
