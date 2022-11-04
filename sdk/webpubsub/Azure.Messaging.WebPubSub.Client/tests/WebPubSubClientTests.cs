// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NETCOREAPP3_1_OR_GREATER
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.WebPubSub.Clients;
using Moq;
using Xunit;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    public class WebPubSubClientTests
    {
        private readonly Mock<IWebSocketClient> _webSocketClientMoc;
        private readonly Mock<IWebSocketClientFactory> _factoryMoc;
        private readonly WebPubSubProtocol _protocol = new WebPubSubJsonReliableProtocol();

        public WebPubSubClientTests()
        {
            _webSocketClientMoc = new Mock<IWebSocketClient>();
            _webSocketClientMoc.SetReturnsDefault(Task.CompletedTask);
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns<CancellationToken>(async token =>
            {
                await Task.Delay(int.MaxValue).AwaitWithCancellation(token);
                return new WebSocketReadResult(new ReadOnlySequence<byte>(), false);
            });
            _factoryMoc = new Mock<IWebSocketClientFactory>();
            _factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns(_webSocketClientMoc.Object);
        }

        [Fact]
        public async Task WebPubSubClientStartStopTest()
        {
            var fetchTcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            var socketStopTcs = new MultipleTimesTaskCompletionSource<object>(10);
            var client = new WebPubSubClient(new WebPubSubClientCredential(_ =>
            {
                fetchTcs.TrySetResult(null);
                return new ValueTask<Uri>(new Uri("wss://test.com"));
            }));
            _webSocketClientMoc.Setup(c => c.StopAsync(It.IsAny<CancellationToken>())).Returns(() =>
            {
                socketStopTcs.IncreaseCallTimes(null);
                return Task.CompletedTask;
            });
            client.WebSocketClientFactory = _factoryMoc.Object;

            await client.StartAsync().OrTimeout();
            Assert.True(fetchTcs.Task.IsCompleted);

            // Another start is not allowed
            await Assert.ThrowsAsync<InvalidOperationException>(() => client.StartAsync()).OrTimeout();

            // Stop should work
            await client.StopAsync().OrTimeout();
            Assert.True(socketStopTcs.VerifyCalledTimesAsync(1).IsCompleted);
            TestUtils.AssertTimeout(socketStopTcs.VerifyCalledTimesAsync(2));

            // After stop we can have another start
            await client.StartAsync().OrTimeout();
            await client.StopAsync().OrTimeout();
            await socketStopTcs.VerifyCalledTimesAsync(2).OrTimeout();
        }

        [Fact]
        public async Task WebPubSubClientStartFailedTest()
        {
            var client = new WebPubSubClient(new WebPubSubClientCredential(_ =>
            {
                return new ValueTask<Uri>(new Uri("wss://test.com"));
            }));
            // throw ex when starting
            _webSocketClientMoc.Setup(c => c.ConnectAsync(It.IsAny<CancellationToken>())).Callback(() => throw new InvalidOperationException());
            client.WebSocketClientFactory = _factoryMoc.Object;

            await Assert.ThrowsAsync<InvalidOperationException>(() => client.StartAsync().OrTimeout());
        }

        [Fact]
        public async Task WebPubSubClientRecoverTest()
        {
            var idx = 0;
            var payloads = new WebSocketReadResult[]
            {
                new WebSocketReadResult(TestUtils.GetConnectedPayload(), false),
                new WebSocketReadResult(default, true, WebSocketCloseStatus.ProtocolError),
            };

            var connectedTcs = NewTcs();
            var disconnectedTcs = new MultipleTimesTaskCompletionSource<object>(100);
            var stoppedTcs = NewTcs();
            var client = new WebPubSubClient(new WebPubSubClientCredential(_ =>
            {
                return new ValueTask<Uri>(new Uri("wss://test.com"));
            }));

            client.Connected += new(e =>
            {
                connectedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });
            client.Disconnected += new(e =>
            {
                disconnectedTcs.IncreaseCallTimes(null);
                return Task.CompletedTask;
            });
            client.Stopped += new(e =>
            {
                stoppedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });
            var connectUriTcs = new MultipleTimesTaskCompletionSource<Uri>(100);
            _factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns<Uri, string>((uri, protocol) =>
            {
                connectUriTcs.IncreaseCallTimes(uri);
                return _webSocketClientMoc.Object;
            });
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns(() =>
            {
                var payload = payloads[idx];
                idx = (idx + 1) % 2;
                return Task.FromResult(payload);
            });
            client.WebSocketClientFactory = _factoryMoc.Object;
            client.RecoverDelay = TimeSpan.FromMilliseconds(100);

            await client.StartAsync().OrTimeout();
            await connectedTcs.Task.OrTimeout();

            var uri1 = await connectUriTcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("wss://test.com/", uri1.AbsoluteUri);

            var uri2 = await connectUriTcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("wss://test.com/?awps_connection_id=connection&awps_reconnection_token=rec", uri2.AbsoluteUri);

            var uri3 = await connectUriTcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.Equal("wss://test.com/?awps_connection_id=connection&awps_reconnection_token=rec", uri3.AbsoluteUri);

            // After stop the recover or reconnect should stop
            await client.StopAsync();
            connectUriTcs.AssertNoMoreCalls();

            // As it's recovery, disconnected should be only called once
            await disconnectedTcs.VerifyCalledTimesAsync(1).OrTimeout();
            TestUtils.AssertTimeout(disconnectedTcs.VerifyCalledTimesAsync(2));
            await stoppedTcs.Task.OrTimeout();
        }

        [Theory]
        [InlineData("reliable", WebSocketCloseStatus.PolicyViolation)]
        [InlineData("unreliable", WebSocketCloseStatus.EndpointUnavailable)]
        public async Task WebPubSubClientRestartTest(string protocol, WebSocketCloseStatus status)
        {
            var idx = 0;
            var payloads = new WebSocketReadResult[]
            {
                new WebSocketReadResult(TestUtils.GetConnectedPayload(), false),
                new WebSocketReadResult(default, true, status),
            };

            var connectedTcs = NewTcs();
            var stoppedTcs = NewTcs();
            var disconnectedTcs = new MultipleTimesTaskCompletionSource<object>(100);
            WebPubSubProtocol p = protocol == "reliable" ? new WebPubSubJsonReliableProtocol() : new WebPubSubJsonProtocol();
            var client = new WebPubSubClient(new WebPubSubClientCredential(_ =>
            {
                return new ValueTask<Uri>(new Uri("wss://test.com"));
            }), new WebPubSubClientOptions() { Protocol = p});

            client.Connected += new(e =>
            {
                connectedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });
            client.Disconnected += new(e =>
            {
                disconnectedTcs.IncreaseCallTimes(null);
                return Task.CompletedTask;
            });
            client.Stopped += new(e =>
            {
                stoppedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });
            var connectUriTcs = new MultipleTimesTaskCompletionSource<Uri>(100);
            _factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns<Uri, string>((uri, protocol) =>
            {
                connectUriTcs.IncreaseCallTimes(uri);
                return _webSocketClientMoc.Object;
            });
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns(() =>
            {
                var payload = payloads[idx];
                idx = (idx + 1) % 2;
                return Task.FromResult(payload);
            });
            client.WebSocketClientFactory = _factoryMoc.Object;
            client.RecoverDelay = TimeSpan.FromMilliseconds(100);

            await client.StartAsync().OrTimeout();
            await connectedTcs.Task.OrTimeout();

            var uri1 = await connectUriTcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.Equal("wss://test.com/", uri1.AbsoluteUri);
            await disconnectedTcs.VerifyCalledTimesAsync(1).OrTimeout();

            var uri2 = await connectUriTcs.VerifyCalledTimesAsync(2).OrTimeout();
            Assert.Equal("wss://test.com/", uri2.AbsoluteUri);
            await disconnectedTcs.VerifyCalledTimesAsync(2).OrTimeout();

            var uri3 = await connectUriTcs.VerifyCalledTimesAsync(3).OrTimeout();
            Assert.Equal("wss://test.com/", uri3.AbsoluteUri);
            await disconnectedTcs.VerifyCalledTimesAsync(3).OrTimeout();

            // After stop the recover or reconnect should stop
            await client.StopAsync();
            connectUriTcs.AssertNoMoreCalls();
            await stoppedTcs.Task.OrTimeout();
        }

        [Fact]
        public async Task WebPubSubNoAutoReconnectTest()
        {
            _webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns(() =>
            {
                // Make the close a PolicyViolation to stop recover
                return Task.FromResult(new WebSocketReadResult(default, true, WebSocketCloseStatus.PolicyViolation));
            });

            var disconnectedTcs = NewTcs();
            var stoppedTcs = NewTcs();
            var client = new WebPubSubClient(new WebPubSubClientCredential(_ =>
            {
                return new ValueTask<Uri>(new Uri("wss://test.com"));
            }), new WebPubSubClientOptions() { AutoReconnect = false });
            client.WebSocketClientFactory = _factoryMoc.Object;
            client.Disconnected += new(e =>
            {
                disconnectedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });
            client.Stopped += new(e =>
            {
                stoppedTcs.TrySetResult(null);
                return Task.CompletedTask;
            });

            await client.StartAsync().OrTimeout();

            // The client will close and stop
            await disconnectedTcs.Task.OrTimeout();
            await stoppedTcs.Task.OrTimeout();
        }

        [Fact]
        public async Task JoinGroupRetryTest()
        {
            var tcs = new MultipleTimesTaskCompletionSource<object>(10);

            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            clientMoc.Setup(c => c.JoinGroupAttemptAsync(It.IsAny<string>(), It.IsAny<ulong?>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                tcs.IncreaseCallTimes(null);
                throw new SendMessageFailedException("msg", null);
            });
            clientMoc.CallBase = true;
            var client = clientMoc.Object;

            await Assert.ThrowsAsync<SendMessageFailedException>(() => client.JoinGroupAsync("group", null, default)).OrTimeout();
            await tcs.VerifyCalledTimesAsync(1).OrTimeout();
            await tcs.VerifyCalledTimesAsync(2).OrTimeout();
            await tcs.VerifyCalledTimesAsync(3).OrTimeout();
            await tcs.VerifyCalledTimesAsync(4).OrTimeout();
            tcs.AssertNoMoreCalls();
        }

        [Fact]
        public async Task LeaveGroupRetryTest()
        {
            var tcs = new MultipleTimesTaskCompletionSource<object>(10);

            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            clientMoc.Setup(c => c.LeaveGroupAttemptAsync(It.IsAny<string>(), It.IsAny<ulong?>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                tcs.IncreaseCallTimes(null);
                throw new SendMessageFailedException("msg", null);
            });
            clientMoc.CallBase = true;
            var client = clientMoc.Object;

            await Assert.ThrowsAsync<SendMessageFailedException>(() => client.LeaveGroupAsync("group", null, default)).OrTimeout();
            await tcs.VerifyCalledTimesAsync(1).OrTimeout();
            await tcs.VerifyCalledTimesAsync(2).OrTimeout();
            await tcs.VerifyCalledTimesAsync(3).OrTimeout();
            await tcs.VerifyCalledTimesAsync(4).OrTimeout();
            tcs.AssertNoMoreCalls();
        }

        [Fact]
        public async Task SendToGroupRetryTest()
        {
            var tcs = new MultipleTimesTaskCompletionSource<object>(10);

            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            clientMoc.Setup(c => c.SendToGroupAttemptAsync(It.IsAny<string>(), It.IsAny<BinaryData>(), It.IsAny<WebPubSubDataType>(),It.IsAny<ulong?>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                tcs.IncreaseCallTimes(null);
                throw new SendMessageFailedException("msg", null);
            });
            clientMoc.CallBase = true;
            var client = clientMoc.Object;

            await Assert.ThrowsAsync<SendMessageFailedException>(() => client.SendToGroupAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text)).OrTimeout();
            await tcs.VerifyCalledTimesAsync(1).OrTimeout();
            await tcs.VerifyCalledTimesAsync(2).OrTimeout();
            await tcs.VerifyCalledTimesAsync(3).OrTimeout();
            await tcs.VerifyCalledTimesAsync(4).OrTimeout();
            tcs.AssertNoMoreCalls();
        }

        [Fact]
        public async Task SendEventRetryTest()
        {
            var tcs = new MultipleTimesTaskCompletionSource<object>(10);

            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), TestUtils.GetClientOptionsForRetryTest());
            clientMoc.Setup(c => c.SendEventAttemptAsync(It.IsAny<string>(), It.IsAny<BinaryData>(), It.IsAny<WebPubSubDataType>(), It.IsAny<ulong?>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                tcs.IncreaseCallTimes(null);
                throw new SendMessageFailedException("msg", null);
            });
            clientMoc.CallBase = true;
            var client = clientMoc.Object;

            await Assert.ThrowsAsync<SendMessageFailedException>(() => client.SendEventAsync("group", BinaryData.FromString("text"), WebPubSubDataType.Text)).OrTimeout();
            await tcs.VerifyCalledTimesAsync(1).OrTimeout();
            await tcs.VerifyCalledTimesAsync(2).OrTimeout();
            await tcs.VerifyCalledTimesAsync(3).OrTimeout();
            await tcs.VerifyCalledTimesAsync(4).OrTimeout();
            tcs.AssertNoMoreCalls();
        }

        private TaskCompletionSource<object> NewTcs() => new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
}
#endif
