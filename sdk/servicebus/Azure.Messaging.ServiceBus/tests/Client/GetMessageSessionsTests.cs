// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    /// <summary>
    /// Unit tests for the <see cref="ServiceBusClient.GetMessageSessionsAsync(string, CancellationToken)"/>
    /// and <see cref="ServiceBusClient.GetMessageSessionsAsync(string, DateTimeOffset, CancellationToken)"/>
    /// queue overloads (and the equivalent topic/subscription overloads). These tests use a mocked
    /// <see cref="ServiceBusConnection"/> and <see cref="TransportReceiver"/> to verify pagination,
    /// sentinel handling, receiver lifecycle, and timestamp conversion without contacting a service.
    ///
    /// Live integration coverage is provided by <see cref="GetMessageSessionsLiveTests"/>.
    /// </summary>
    public class GetMessageSessionsTests
    {
        [Test]
        public async Task GetMessageSessions_StopsWhenPageIsShorterThanPageSize()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "s1", "s2" });

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions, Is.EquivalentTo(new[] { "s1", "s2" }));
            mockTransportReceiver.Verify(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.Once,
                "Pagination should stop when a page is shorter than the page size.");
        }

        [Test]
        public async Task GetMessageSessions_AggregatesResultsAcrossPages()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            // First page is full (100), second page is full (100), third is short (signals end).
            var fullPage1 = BuildSessionIds("a-", 100);
            var fullPage2 = BuildSessionIds("b-", 100);
            var shortPage = new[] { "tail-1", "tail-2" };

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(fullPage1)
                .ReturnsAsync(fullPage2)
                .ReturnsAsync(shortPage);

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions.Count, Is.EqualTo(202));
            Assert.That(sessions[0], Is.EqualTo("a-0"));
            Assert.That(sessions[100], Is.EqualTo("b-0"));
            Assert.That(sessions[200], Is.EqualTo("tail-1"));
        }

        [Test]
        public async Task GetMessageSessions_StopsOnEmptyPage()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(BuildSessionIds("p-", 100))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions.Count, Is.EqualTo(100));
            mockTransportReceiver.Verify(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2),
                "Pagination should stop on the first empty page after a full page.");
        }

        [Test]
        public async Task GetMessageSessions_PassesDateTimeOffsetMaxValueWhenNoSessionStateUpdatedAfter()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            DateTimeOffset capturedTimestamp = default;
            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Callback<DateTimeOffset, int, int, CancellationToken>(
                    (lastUpdatedTime, _, _, _) => capturedTimestamp = lastUpdatedTime)
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync("queue"))
            {
            }

            // The no-filter overload must pass DateTimeOffset.MaxValue as the sentinel; the service
            // interprets this as 'all sessions with active messages'.
            Assert.That(capturedTimestamp, Is.EqualTo(DateTimeOffset.MaxValue),
                "The no-filter overload must pass DateTimeOffset.MaxValue as the sentinel.");
        }

        [Test]
        public async Task GetMessageSessions_PassesSessionStateUpdatedAfterThrough()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            DateTimeOffset capturedTimestamp = default;
            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Callback<DateTimeOffset, int, int, CancellationToken>(
                    (lastUpdatedTime, _, _, _) => capturedTimestamp = lastUpdatedTime)
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            // Construct a non-UTC offset so we can verify it is passed through as-is.
            var nonUtcOffset = new DateTimeOffset(2026, 1, 15, 10, 0, 0, TimeSpan.FromHours(-5));
            await foreach (var _ in client.GetMessageSessionsAsync("queue", nonUtcOffset))
            {
            }

            Assert.That(capturedTimestamp, Is.EqualTo(nonUtcOffset),
                "The sessionStateUpdatedAfter overload must pass the DateTimeOffset through to the transport.");
        }

        [Test]
        public async Task GetMessageSessions_Subscription_PassesFormattedSubscriptionPath()
        {
            const string topicName = "my-topic";
            const string subscriptionName = "my-subscription";
            var expectedEntityPath = EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName);

            var mockTransportReceiver = new Mock<TransportReceiver>();

            // Capture the entityPath the client passes into CreateTransportReceiver.
            string capturedEntityPath = null;
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, ServiceBusRetryPolicy, ServiceBusReceiveMode, uint, string, string, bool, bool, CancellationToken>(
                    (entityPath, _, _, _, _, _, _, _, _) => capturedEntityPath = entityPath)
                .Returns(mockTransportReceiver.Object);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync(topicName, subscriptionName))
            {
            }

            Assert.That(capturedEntityPath, Is.EqualTo(expectedEntityPath),
                "The subscription overload must format and pass the subscription entity path.");
            mockTransportReceiver.Verify(
                receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.AtLeastOnce,
                "The pagination loop must reach the transport receiver against the formatted subscription path.");
        }

        [Test]
        public async Task GetMessageSessions_ClosesReceiverAfterSuccess()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync("queue"))
            {
            }

            mockTransportReceiver.Verify(
                receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()),
                Times.Once,
                "The transport receiver must be closed after a successful query.");
        }

        [Test]
        public void GetMessageSessions_ClosesReceiverWhenTransportThrows()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTimeOffset>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ServiceBusException(true, "transport boom"));

            var client = new ServiceBusClient(mockConnection.Object);

            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await foreach (var _ in client.GetMessageSessionsAsync("queue"))
                {
                }
            });

            mockTransportReceiver.Verify(
                receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()),
                Times.Once,
                "The transport receiver must be closed even when the transport call throws.");
        }

        private static string[] BuildSessionIds(string prefix, int count)
        {
            var ids = new string[count];
            for (int i = 0; i < count; i++)
            {
                ids[i] = prefix + i;
            }
            return ids;
        }

        private static Mock<ServiceBusConnection> GetMockConnection(Mock<TransportReceiver> mockTransportReceiver)
        {
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(mockTransportReceiver.Object);

            return mockConnection;
        }
    }
}
