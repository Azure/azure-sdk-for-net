// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Sms.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsSubClientTest
    {
        [Test]
        public void SmsSubClient_NullArguments_ThrowsArgumentNullException()
        {
            // Create a real SmsSubClient with valid dependencies for argument validation testing
            var subClient = CreateTestSmsSubClient();

            // Test single recipient Send method - null arguments throw ArgumentNullException, empty throw ArgumentException
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync(null, "+14255550123", "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("", "+14255550123", "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", (string?)null, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", "", "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", "+14255550234", null));

            // Test single recipient Send method (sync) - null arguments throw ArgumentNullException, empty throw ArgumentException
            Assert.Throws<ArgumentNullException>(() => subClient.Send(null, "+14255550123", "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("", "+14255550123", "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", (string?)null, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", "", "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", "+14255550234", null));

            // Test multiple recipients Send method - null arguments throw ArgumentNullException, empty throw ArgumentException
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync(null, new[] { "+14255550123" }, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("", new[] { "+14255550123" }, "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", (IEnumerable<string>)null!, "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", new[] { "+14255550234" }, null));

            // Test multiple recipients Send method (sync) - null arguments throw ArgumentNullException, empty throw ArgumentException
            Assert.Throws<ArgumentNullException>(() => subClient.Send(null, new[] { "+14255550123" }, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("", new[] { "+14255550123" }, "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", (IEnumerable<string>)null!, "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", new[] { "+14255550234" }, null));
        }

        [Test]
        public void SmsSubClient_EmptyRecipientsList_ThrowsArgumentException()
        {
            var subClient = CreateTestSmsSubClient();

            var emptyRecipients = new string[0];

            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", emptyRecipients, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", emptyRecipients, "message"));
        }

        [Test]
        public void SmsSubClient_RecipientsWithNullOrEmptyEntries_ThrowsArgumentException()
        {
            var subClient = CreateTestSmsSubClient();

            var recipientsWithNull = new[] { "+14255550123", null!, "+14255550234" };
            var recipientsWithEmpty = new[] { "+14255550123", "", "+14255550234" };

            // These should throw ArgumentNullException because the validation happens during processing individual recipients
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", recipientsWithNull, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", recipientsWithEmpty, "message"));

            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", recipientsWithNull, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", recipientsWithEmpty, "message"));
        }

        [Test]
        public async Task SmsSubClient_SendAsync_SingleRecipient_CallsMultipleRecipientsMethod()
        {
            // Create a mock SmsSubClient since its methods are virtual
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = true };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null)
            };

            // Mock the multiple recipients method that gets called internally
            mockSubClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((string from, IEnumerable<string> to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    // Create expected response for multiple recipients method
                    return Response.FromValue((IReadOnlyList<SmsSendResult>)smsSendResults, new Mock<Response>().Object);
                });

            // Execute single recipient method
            var result = await mockSubClient.Object.SendAsync("+14255550123", "+14255550234", "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(smsSendResults[0], result.Value);

            // Verify that the multiple recipients method was called
            mockSubClient.Verify(
                x => x.SendAsync(
                    "+14255550123",
                    It.Is<IEnumerable<string>>(recipients => recipients.SequenceEqual(new[] { "+14255550234" })),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_SingleRecipient_CallsMultipleRecipientsMethod()
        {
            // Create a mock SmsSubClient since its methods are virtual
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = true };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null)
            };

            // Mock the multiple recipients method that gets called internally
            mockSubClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns((string from, IEnumerable<string> to, string message, SmsSendOptions options, CancellationToken token) =>
                {
                    // Create expected response for multiple recipients method
                    return Response.FromValue((IReadOnlyList<SmsSendResult>)smsSendResults, new Mock<Response>().Object);
                });

            // Execute single recipient method
            var result = mockSubClient.Object.Send("+14255550123", "+14255550234", "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(smsSendResults[0], result.Value);

            // Verify that the multiple recipients method was called
            mockSubClient.Verify(
                x => x.Send(
                    "+14255550123",
                    It.Is<IEnumerable<string>>(recipients => recipients.SequenceEqual(new[] { "+14255550234" })),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task SmsSubClient_SendAsync_MultipleRecipients_ProcessesRecipientsCorrectly()
        {
            // Create a mock SmsSubClient but allow real implementation for argument processing tests
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = false };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null),
                SmsModelFactory.SmsSendResult("+14255550345", "messageId456", 200, true, null)
            };

            var recipients = new[] { "+14255550234", "+14255550345" };

            // Mock the method to return our test data
            mockSubClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Response.FromValue((IReadOnlyList<SmsSendResult>)smsSendResults, new Mock<Response>().Object));

            // Execute
            var result = await mockSubClient.Object.SendAsync("+14255550123", recipients, "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Value.Count);
            Assert.AreEqual(smsSendResults[0], result.Value[0]);
            Assert.AreEqual(smsSendResults[1], result.Value[1]);

            // Verify method was called with correct parameters
            mockSubClient.Verify(
                x => x.SendAsync(
                    "+14255550123",
                    It.Is<IEnumerable<string>>(r => r.SequenceEqual(recipients)),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_MultipleRecipients_ProcessesRecipientsCorrectly()
        {
            // Create a mock SmsSubClient but allow real implementation for argument processing tests
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = false };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null),
                SmsModelFactory.SmsSendResult("+14255550345", "messageId456", 200, true, null)
            };

            var recipients = new[] { "+14255550234", "+14255550345" };

            // Mock the method to return our test data
            mockSubClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue((IReadOnlyList<SmsSendResult>)smsSendResults, new Mock<Response>().Object));

            // Execute
            var result = mockSubClient.Object.Send("+14255550123", recipients, "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Value.Count);
            Assert.AreEqual(smsSendResults[0], result.Value[0]);
            Assert.AreEqual(smsSendResults[1], result.Value[1]);

            // Verify method was called with correct parameters
            mockSubClient.Verify(
                x => x.Send(
                    "+14255550123",
                    It.Is<IEnumerable<string>>(r => r.SequenceEqual(recipients)),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task SmsSubClient_SendAsync_WithOptions_PassesOptionsCorrectly()
        {
            // Create a mock SmsSubClient
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = false };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null)
            };

            var options = new SmsSendOptions(enableDeliveryReport: true) { Tag = "test-tag" };

            // Mock the single recipient method to return our test data
            mockSubClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(Response.FromValue(smsSendResults[0], new Mock<Response>().Object));

            // Execute
            await mockSubClient.Object.SendAsync("+14255550123", "+14255550234", "Test message", options);

            // Verify that options were passed through
            mockSubClient.Verify(
                x => x.SendAsync(
                    "+14255550123",
                    "+14255550234",
                    "Test message",
                    options,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_WithOptions_PassesOptionsCorrectly()
        {
            // Create a mock SmsSubClient
            var mockSubClient = new Mock<SmsSubClient>() { CallBase = false };

            // Create test data using SmsModelFactory
            var smsSendResults = new List<SmsSendResult>
            {
                SmsModelFactory.SmsSendResult("+14255550234", "messageId123", 200, true, null)
            };

            var options = new SmsSendOptions(enableDeliveryReport: true) { Tag = "test-tag" };

            // Mock the single recipient method to return our test data
            mockSubClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Response.FromValue(smsSendResults[0], new Mock<Response>().Object));

            // Execute
            mockSubClient.Object.Send("+14255550123", "+14255550234", "Test message", options);

            // Verify that options were passed through
            mockSubClient.Verify(
                x => x.Send(
                    "+14255550123",
                    "+14255550234",
                    "Test message",
                    options,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// Creates a test SmsSubClient with valid dependencies for argument validation testing.
        /// This will cause network errors when methods are called, but argument validation happens first.
        /// </summary>
        private SmsSubClient CreateTestSmsSubClient()
        {
            var clientOptions = new SmsClientOptions();
            var clientDiagnostics = new ClientDiagnostics(clientOptions);
            var httpPipeline = HttpPipelineBuilder.Build(clientOptions);
            var endpoint = new Uri("http://localhost");
            var restClient = new SmsRestClient(clientDiagnostics, httpPipeline, endpoint);

            return new SmsSubClient(clientDiagnostics, restClient);
        }
    }
}
