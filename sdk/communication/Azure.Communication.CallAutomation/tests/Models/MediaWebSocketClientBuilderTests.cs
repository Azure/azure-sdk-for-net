// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Models
{
    public class MediaWebSocketClientBuilderTests
    {
        private const string ConnectionString = "endpoint=https://contoso.communication.azure.com/;accesskey=dGVzdA==";

        [Test]
        public void Builder_WithCallAutomationClient_ReturnsBuilder()
        {
            var client = new CallAutomationClient(ConnectionString);

            var builder = MediaWebSocketClient.Builder(client);

            Assert.That(builder, Is.Not.Null);
            Assert.That(builder, Is.InstanceOf<MediaWebSocketClient.MediaWebSocketBuilder>());
        }

        [Test]
        public void Builder_WithNullClient_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MediaWebSocketClient.Builder(null!));
        }

        [Test]
        public void BuildAndConnectAsync_WithoutStreamUrl_ThrowsInvalidOperationException()
        {
            var client = new CallAutomationClient(ConnectionString);
            var builder = MediaWebSocketClient.Builder(client);

            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await builder.BuildAndConnectAsync());
        }

        [Test]
        public void WithStreamUrl_String_SetsUrl()
        {
            var client = new CallAutomationClient(ConnectionString);

            var builder = MediaWebSocketClient.Builder(client)
                .WithStreamUrl("wss://contoso.communication.azure.com/stream");

            Assert.That(builder, Is.Not.Null);
        }

        [Test]
        public void WithStreamUrl_Null_ThrowsArgumentNullException()
        {
            var client = new CallAutomationClient(ConnectionString);

            Assert.Throws<ArgumentNullException>(() =>
                MediaWebSocketClient.Builder(client).WithStreamUrl((string)null!));
        }

        [Test]
        public void WithHeader_ValidInput_ReturnsBuilder()
        {
            var client = new CallAutomationClient(ConnectionString);

            var builder = MediaWebSocketClient.Builder(client)
                .WithCustomHeader("X-App-Name", "MyApp")
                .WithCustomHeader("X-Correlation-Id", "abc123");

            Assert.That(builder, Is.Not.Null);
        }

        [Test]
        public void WithHeader_EmptyName_ThrowsArgumentException()
        {
            var client = new CallAutomationClient(ConnectionString);

            Assert.Throws<ArgumentException>(() =>
                MediaWebSocketClient.Builder(client).WithCustomHeader("", "value"));
        }

        [Test]
        public void FluentChaining_AllOptions_ReturnsBuilder()
        {
            var client = new CallAutomationClient(ConnectionString);

            var builder = MediaWebSocketClient.Builder(client)
                .WithStreamUrl("wss://contoso.communication.azure.com/stream")
                .WithCustomHeader("X-App-Name", "MyApp")
                .WithCustomHeader("X-Correlation-Id", "abc123")
                .WithConnectTimeout(TimeSpan.FromSeconds(10))
                .WithKeepAliveInterval(TimeSpan.FromSeconds(30))
                .WithBufferSize(4096, 4096)
                .WithSubProtocol("graphql-ws");

            Assert.That(builder, Is.Not.Null);
        }
    }
}
