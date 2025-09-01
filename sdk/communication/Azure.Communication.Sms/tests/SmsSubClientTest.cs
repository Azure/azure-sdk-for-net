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
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();
            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);

            // Test single recipient Send method
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync(null, "+14255550123", "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("", "+14255550123", "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", (string?)null, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", "", "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", "+14255550234", null));

            // Test single recipient Send method (sync)
            Assert.Throws<ArgumentException>(() => subClient.Send(null, "+14255550123", "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("", "+14255550123", "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", (string?)null, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", "", "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", "+14255550234", null));

            // Test multiple recipients Send method
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync(null, new[] { "+14255550123" }, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("", new[] { "+14255550123" }, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", (IEnumerable<string>)null!, "message"));
            Assert.ThrowsAsync<ArgumentNullException>(() => subClient.SendAsync("+14255550123", new[] { "+14255550234" }, null));

            // Test multiple recipients Send method (sync)
            Assert.Throws<ArgumentException>(() => subClient.Send(null, new[] { "+14255550123" }, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("", new[] { "+14255550123" }, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", (IEnumerable<string>)null!, "message"));
            Assert.Throws<ArgumentNullException>(() => subClient.Send("+14255550123", new[] { "+14255550234" }, null));
        }

        [Test]
        public void SmsSubClient_EmptyRecipientsList_ThrowsArgumentException()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();
            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);

            var emptyRecipients = new string[0];

            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", emptyRecipients, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", emptyRecipients, "message"));
        }

        [Test]
        public void SmsSubClient_RecipientsWithNullOrEmptyEntries_ThrowsArgumentException()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();
            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);

            var recipientsWithNull = new[] { "+14255550123", null!, "+14255550234" };
            var recipientsWithEmpty = new[] { "+14255550123", "", "+14255550234" };

            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", recipientsWithNull, "message"));
            Assert.ThrowsAsync<ArgumentException>(() => subClient.SendAsync("+14255550123", recipientsWithEmpty, "message"));

            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", recipientsWithNull, "message"));
            Assert.Throws<ArgumentException>(() => subClient.Send("+14255550123", recipientsWithEmpty, "message"));
        }

        [Test]
        public async Task SmsSubClient_SendAsync_SingleRecipient_CallsMultipleRecipientsMethod()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);

            // Execute
            var result = await subClient.SendAsync("+14255550123", "+14255550234", "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(smsSendResults[0], result.Value);

            // Verify that the underlying SendAsync method was called with correct parameters
            mockRestClient.Verify(
                x => x.SendAsync(
                    "+14255550123",
                    It.Is<IEnumerable<SmsRecipient>>(recipients =>
                        recipients.Count() == 1 &&
                        recipients.First().To == "+14255550234"),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_SingleRecipient_CallsMultipleRecipientsMethod()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);

            // Execute
            var result = subClient.Send("+14255550123", "+14255550234", "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(smsSendResults[0], result.Value);

            // Verify that the underlying Send method was called with correct parameters
            mockRestClient.Verify(
                x => x.Send(
                    "+14255550123",
                    It.Is<IEnumerable<SmsRecipient>>(recipients =>
                        recipients.Count() == 1 &&
                        recipients.First().To == "+14255550234"),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task SmsSubClient_SendAsync_MultipleRecipients_CreatesCorrectSmsRecipients()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true),
                CreateMockSmsSendResult("+14255550345", "messageId456", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);
            var recipients = new[] { "+14255550234", "+14255550345" };

            // Execute
            var result = await subClient.SendAsync("+14255550123", recipients, "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Value.Count);

            // Verify that the underlying SendAsync method was called with correct parameters
            mockRestClient.Verify(
                x => x.SendAsync(
                    "+14255550123",
                    It.Is<IEnumerable<SmsRecipient>>(smsRecipients =>
                        smsRecipients.Count() == 2 &&
                        smsRecipients.All(r => r.RepeatabilityRequestId != null) &&
                        smsRecipients.All(r => r.RepeatabilityFirstSent != null) &&
                        smsRecipients.Select(r => r.To).SequenceEqual(recipients)),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_MultipleRecipients_CreatesCorrectSmsRecipients()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true),
                CreateMockSmsSendResult("+14255550345", "messageId456", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);
            var recipients = new[] { "+14255550234", "+14255550345" };

            // Execute
            var result = subClient.Send("+14255550123", recipients, "Test message");

            // Verify
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Value.Count);

            // Verify that the underlying Send method was called with correct parameters
            mockRestClient.Verify(
                x => x.Send(
                    "+14255550123",
                    It.Is<IEnumerable<SmsRecipient>>(smsRecipients =>
                        smsRecipients.Count() == 2 &&
                        smsRecipients.All(r => r.RepeatabilityRequestId != null) &&
                        smsRecipients.All(r => r.RepeatabilityFirstSent != null) &&
                        smsRecipients.Select(r => r.To).SequenceEqual(recipients)),
                    "Test message",
                    null,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task SmsSubClient_SendAsync_WithOptions_PassesOptionsCorrectly()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);
            var options = new SmsSendOptions(enableDeliveryReport: true) { Tag = "test-tag" };

            // Execute
            await subClient.SendAsync("+14255550123", "+14255550234", "Test message", options);

            // Verify that options were passed through
            mockRestClient.Verify(
                x => x.SendAsync(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    options,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public void SmsSubClient_Send_WithOptions_PassesOptionsCorrectly()
        {
            var mockRestClient = new Mock<SmsRestClient>();
            var mockDiagnostics = new Mock<ClientDiagnostics>();

            // Setup mock response
            var mockSmsSendResponse = new Mock<SmsSendResponse>();
            var smsSendResults = new List<SmsSendResult>
            {
                CreateMockSmsSendResult("+14255550234", "messageId123", 200, true)
            };

            mockSmsSendResponse.SetupGet(x => x.Value).Returns(smsSendResults);
            var mockResponse = Response.FromValue(mockSmsSendResponse.Object, new Mock<Response>().Object);

            mockRestClient
                .Setup(x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    It.IsAny<SmsSendOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns(mockResponse);

            var subClient = new SmsSubClient(mockDiagnostics.Object, mockRestClient.Object);
            var options = new SmsSendOptions(enableDeliveryReport: true) { Tag = "test-tag" };

            // Execute
            subClient.Send("+14255550123", "+14255550234", "Test message", options);

            // Verify that options were passed through
            mockRestClient.Verify(
                x => x.Send(
                    It.IsAny<string>(),
                    It.IsAny<IEnumerable<SmsRecipient>>(),
                    It.IsAny<string>(),
                    options,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        private static SmsSendResult CreateMockSmsSendResult(string to, string messageId, int httpStatusCode, bool successful)
        {
            // Using reflection to create SmsSendResult since constructor is internal
            var constructor = typeof(SmsSendResult).GetConstructor(
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null,
                new[] { typeof(string), typeof(int), typeof(bool) },
                null);

            if (constructor != null)
            {
                return (SmsSendResult)constructor.Invoke(new object[] { to, httpStatusCode, successful });
            }

            throw new InvalidOperationException("Could not create SmsSendResult for testing");
        }
    }
}
