// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Messaging.WebPubSub.Client.Tests.Utils;
using Azure.Messaging.WebPubSub.Clients;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Client.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class WebPubSubClientInvokeEventTests
    {
        private Mock<IWebSocketClient> _webSocketClientMoc;
        private Mock<IWebSocketClientFactory> _factoryMoc;
        private WebPubSubProtocol _protocol;

        [SetUp]
        public void Setup()
        {
            _protocol = new WebPubSubJsonReliableProtocol();
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

        [Test]
        public async Task InvokeEventResolvesWithInvokeResponsePayload()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.InvokeEventAttemptAsync("echo", BinaryData.FromString("ping"), WebPubSubDataType.Text, "invoke-1", default);
            TestUtils.AssertTimeout(t);

            client.HandleInvokeResponseMessage(new InvokeResponseMessage("invoke-1", true, WebPubSubDataType.Text, BinaryData.FromString("pong"), null));
            var result = await t.OrTimeout();

            Assert.AreEqual("invoke-1", result.InvocationId);
            Assert.AreEqual(WebPubSubDataType.Text, result.DataType);
            Assert.AreEqual("pong", result.Data.ToString());
        }

        [Test]
        public void InvokeEventRejectsWhenServiceReturnsError()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.InvokeEventAttemptAsync("echo", BinaryData.FromString("ping"), WebPubSubDataType.Text, "invoke-error", default);
            TestUtils.AssertTimeout(t);

            client.HandleInvokeResponseMessage(new InvokeResponseMessage("invoke-error", false, null, null, new InvokeResponseError("BadRequest", "oops")));
            var ex = Assert.ThrowsAsync<InvocationFailedException>(() => t);
            Assert.AreEqual("invoke-error", ex.InvocationId);
            Assert.AreEqual("BadRequest", ex.Code);
            Assert.AreEqual("oops", ex.Message);
        }

        [Test]
        public async Task InvokeEventWithJsonResponsePayload()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            var t = client.InvokeEventAttemptAsync("echo", BinaryData.FromObjectAsJson(new { key = "value" }), WebPubSubDataType.Json, "invoke-json", default);
            TestUtils.AssertTimeout(t);

            client.HandleInvokeResponseMessage(new InvokeResponseMessage("invoke-json", true, WebPubSubDataType.Json, BinaryData.FromObjectAsJson(new { key = "value" }), null));
            var result = await t.OrTimeout();

            Assert.AreEqual("invoke-json", result.InvocationId);
            Assert.AreEqual(WebPubSubDataType.Json, result.DataType);
            Assert.IsNotNull(result.Data);
        }

        [Test]
        public void InvokeEventCancellationThrowsOperationCanceledException()
        {
            var clientMoc = new Mock<WebPubSubClient>(new Uri("wss://test.com"), new WebPubSubClientOptions() { AutoReconnect = false });
            clientMoc.CallBase = true;
            clientMoc.Setup(c => c.SendCoreAsync(It.IsAny<ReadOnlyMemory<byte>>(), It.IsAny<WebPubSubProtocolMessageType>(), It.IsAny<bool>(), It.IsAny<CancellationToken>())).Returns(() =>
            {
                return Task.CompletedTask;
            });
            var client = clientMoc.Object;
            client.WebSocketClientFactory = _factoryMoc.Object;

            using var cts = new CancellationTokenSource();
            var task = client.InvokeEventAttemptAsync("echo", BinaryData.FromString("ping"), WebPubSubDataType.Text, "invoke-cancel", cts.Token);

            cts.Cancel();
            Assert.ThrowsAsync<OperationCanceledException>(async () => await task);
        }

        [Test]
        public async Task InvokeEventSendMessageTest()
        {
            var tcs = new MultipleTimesTaskCompletionSource<WebPubSubMessage>(100);
            var webSocketClientMoc = new Mock<IWebSocketClient>();
            webSocketClientMoc.SetReturnsDefault(Task.CompletedTask);
            webSocketClientMoc.Setup(c => c.ReceiveOneFrameAsync(It.IsAny<CancellationToken>())).Returns<CancellationToken>(async token =>
            {
                await Task.Delay(int.MaxValue).AwaitWithCancellation(token);
                return new WebSocketReadResult(new ReadOnlySequence<byte>(), false);
            });
            var factoryMoc = new Mock<IWebSocketClientFactory>();
            factoryMoc.Setup(f => f.CreateWebSocketClient(It.IsAny<Uri>(), It.IsAny<string>())).Returns(webSocketClientMoc.Object);
            var protocolMoc = new Mock<WebPubSubProtocol>();
            protocolMoc.Setup(p => p.GetMessageBytes(It.IsAny<WebPubSubMessage>())).Returns<WebPubSubMessage>(msg =>
            {
                tcs.IncreaseCallTimes(msg);
                return default;
            });
            var wpsClient = new WebPubSubClient(new Uri("wss://test.com"), new WebPubSubClientOptions() { Protocol = protocolMoc.Object });

            // Fire and forget - we just want to verify the message is sent
            _ = wpsClient.InvokeEventAttemptAsync("event", BinaryData.FromString("text"), WebPubSubDataType.Text, "test-invoke-id", default);
            var msg = (InvokeMessage)await tcs.VerifyCalledTimesAsync(1).OrTimeout();
            Assert.AreEqual("event", msg.EventName);
            Assert.AreEqual("text", msg.Data.ToString());
            Assert.AreEqual(WebPubSubDataType.Text, msg.DataType);
            Assert.AreEqual("test-invoke-id", msg.InvocationId);
        }
    }
}
