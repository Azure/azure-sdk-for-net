// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.VoiceLive.Diagnostics;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    /// <summary>
    /// Tests for WebSocket content logging functionality in VoiceLive.
    /// </summary>
    [TestFixture]
    public class ContentLoggingTests : VoiceLiveTestBase
    {
        private readonly List<EventWrittenEventArgs> _capturedEvents = new();
        private TestEventListener? _eventListener;
        private VoiceLiveClient? _client;

        public ContentLoggingTests() : base(true) { }

        public ContentLoggingTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public override void Setup()
        {
            _capturedEvents.Clear();
            _eventListener = new TestEventListener(_capturedEvents);

            var endpoint = new Uri("wss://test.example.com");
            var credential = new AzureKeyCredential("test-key");
            _client = InstrumentClient(new VoiceLiveClient(endpoint, credential));
            base.Setup();
        }

        [TearDown]
        public void TearDown()
        {
            _eventListener?.Dispose();
            _eventListener = null;
        }

        [Test]
        public void ContentLogger_IsContentLoggingEnabled_RespectsConfiguration()
        {
            // Arrange
            var optionsEnabled = new VoiceLiveClientOptions();
            optionsEnabled.Diagnostics.IsLoggingEnabled = true;
            optionsEnabled.Diagnostics.IsLoggingContentEnabled = true;

            var optionsContentDisabled = new VoiceLiveClientOptions();
            optionsContentDisabled.Diagnostics.IsLoggingEnabled = true;
            optionsContentDisabled.Diagnostics.IsLoggingContentEnabled = false;

            var optionsLoggingDisabled = new VoiceLiveClientOptions();
            optionsLoggingDisabled.Diagnostics.IsLoggingEnabled = false;
            optionsLoggingDisabled.Diagnostics.IsLoggingContentEnabled = true;

            // Act
            var loggerEnabled = new VoiceLiveWebSocketContentLogger(optionsEnabled.Diagnostics);
            var loggerContentDisabled = new VoiceLiveWebSocketContentLogger(optionsContentDisabled.Diagnostics);
            var loggerLoggingDisabled = new VoiceLiveWebSocketContentLogger(optionsLoggingDisabled.Diagnostics);

            // Assert
            Assert.IsTrue(loggerEnabled?.IsContentLoggingEnabled);
            Assert.IsFalse(loggerContentDisabled?.IsContentLoggingEnabled);
            Assert.IsFalse(loggerLoggingDisabled?.IsContentLoggingEnabled);
        }

        [Test]
        public void ContentLogger_IsLoggingEnabled_RespectsConfiguration()
        {
            // Arrange
            var optionsEnabled = new VoiceLiveClientOptions();
            optionsEnabled.Diagnostics.IsLoggingEnabled = true;

            var optionsDisabled = new VoiceLiveClientOptions();
            optionsDisabled.Diagnostics.IsLoggingEnabled = false;

            // Act
            var loggerEnabled = new VoiceLiveWebSocketContentLogger(optionsEnabled.Diagnostics);
            var loggerDisabled = new VoiceLiveWebSocketContentLogger(optionsDisabled.Diagnostics);

            // Assert
            Assert.IsTrue(loggerEnabled.IsLoggingEnabled);
            Assert.IsFalse(loggerDisabled.IsLoggingEnabled);
        }

        [LiveOnly]
        [Test]
        public async Task Session_WithContentLoggingEnabled_LogsConnectionOpen()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };

            var client = GetLiveClient(options);
            var session = await client.StartSessionAsync("gpt-4o").ConfigureAwait(false);

            // Assert
            var connectionOpenEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent);

            Assert.IsNotNull(connectionOpenEvent, "Connection open event should be logged");

            Assert.AreEqual(EventLevel.Informational, connectionOpenEvent?.Level);
            Assert.IsTrue(connectionOpenEvent is not null && connectionOpenEvent.Message is not null && connectionOpenEvent.Message.Contains("WebSocket") && connectionOpenEvent.Message.Contains("opening"));
        }

        [Test]
        public async Task Session_WithContentLoggingEnabled_LogsConnectionClose()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            _capturedEvents.Clear(); // Clear connection events

            // Act
            await session.CloseAsync(CancellationToken.None);

            // Assert
            var connectionCloseEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketConnectionClosedEvent);

            Assert.IsNotNull(connectionCloseEvent, "Connection close event should be logged");
            Assert.AreEqual(EventLevel.Informational, connectionCloseEvent?.Level);
            Assert.IsTrue(connectionCloseEvent is not null && connectionCloseEvent.Message is not null && connectionCloseEvent.Message.Contains("WebSocket") && connectionCloseEvent.Message.Contains("closed"));
        }

        [Test]
        public async Task Session_WithContentLoggingEnabled_LogsSentMessages()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            _capturedEvents.Clear(); // Clear connection events

            var testMessage = """{"type": "session.update", "session": {"voice": "alloy"}}""";
            var testData = BinaryData.FromString(testMessage);

            // Act
            await session.SendCommandAsync(testData, CancellationToken.None);

            // Assert
            var messageSentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentEvent);
            var contentSentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent);

            Assert.IsNotNull(messageSentEvent, "Message sent event should be logged");
            Assert.AreEqual(EventLevel.Informational, messageSentEvent?.Level);

            Assert.IsNotNull(contentSentEvent, "Content sent event should be logged");
            Assert.AreEqual(EventLevel.Verbose, contentSentEvent?.Level);
            Assert.IsTrue(contentSentEvent?.Message?.Contains("sent content"));
        }

        [Test]
        public async Task Session_WithContentLoggingEnabled_LogsReceivedMessages()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            _capturedEvents.Clear(); // Clear connection events

            var testMessage = """{"type": "session.created", "session": {"id": "test-session"}}""";
            fakeWebSocket.EnqueueTextMessage(testMessage);

            // Act
            await foreach (var update in session.ReceiveUpdatesAsync().WithCancellation(new CancellationTokenSource(TimeSpan.FromSeconds(1)).Token))
            {
                break; // Just process one message
            }

            // Assert
            var messageReceivedEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageReceivedEvent);
            var contentReceivedEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageReceivedContentTextEvent);

            Assert.IsNotNull(messageReceivedEvent, "Message received event should be logged");
            Assert.AreEqual(EventLevel.Informational, messageReceivedEvent?.Level);

            Assert.IsNotNull(contentReceivedEvent, "Content received event should be logged");
            Assert.AreEqual(EventLevel.Verbose, contentReceivedEvent?.Level);
            Assert.IsTrue(contentReceivedEvent?.Message?.Contains("received content"));
        }

        [Test]
        public async Task Session_WithContentLoggingDisabled_DoesNotLogContent()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = false }
            };
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            _capturedEvents.Clear(); // Clear connection events

            var testMessage = """{"type": "session.update", "session": {"voice": "alloy"}}""";
            var testData = BinaryData.FromString(testMessage);

            // Act
            await session.SendCommandAsync(testData, CancellationToken.None);

            // Assert
            var messageSentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentEvent);
            var contentSentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent);

            Assert.IsNotNull(messageSentEvent, "Message sent event should still be logged");
            Assert.IsNull(contentSentEvent, "Content sent event should NOT be logged when content logging is disabled");
        }

        [Test]
        public void ContentLogger_TruncatesLargeContent()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;
            options.Diagnostics.LoggedContentSizeLimit = 100; // Small limit for testing

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);
            var largeContent = new byte[200]; // Larger than limit
            for (int i = 0; i < largeContent.Length; i++)
            {
                largeContent[i] = (byte)(i % 256);
            }

            // Act
            logger.LogSentMessage("test-conn", largeContent, isText: false);

            // Assert
            var contentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentEvent);

            Assert.IsNotNull(contentEvent, "Content event should be logged");
            Assert.IsNotNull(contentEvent?.Payload, "Event payload should not be null");
            Assert.IsTrue(contentEvent?.Payload?.Count > 1, "Event payload should have at least 2 items");
            var loggedContent = (byte[])contentEvent?.Payload?[1]!;
            Assert.AreEqual(100, loggedContent?.Length, "Content should be truncated to the specified limit");
        }

        [Test]
        public void ContentLogger_LogsErrorContent_AtInformationalLevel()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);
            var errorMessage = "Test error message"u8.ToArray();

            // Act
            logger.LogError("test-conn", "WebSocket error", errorMessage, isText: true);

            // Assert
            var errorEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorEvent);
            var errorContentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent);

            Assert.IsNotNull(errorEvent, "Error event should be logged");
            Assert.AreEqual(EventLevel.Warning, errorEvent?.Level);

            Assert.IsNotNull(errorContentEvent, "Error content event should be logged");
            Assert.AreEqual(EventLevel.Informational, errorContentEvent?.Level, "Error content should be logged at Informational level");
        }

        [Test]
        public void AzureVoiceLiveEventSource_HasCorrectEventSourceName()
        {
            // Arrange & Act
            var eventSource = AzureVoiceLiveEventSource.Singleton;

            // Assert
            Assert.AreEqual("Azure-VoiceLive", eventSource?.Name);
        }

        [Test]
        public void AzureVoiceLiveEventSource_HasUniqueEventIds()
        {
            // This test ensures that our event IDs don't conflict with each other
            // Event IDs should be in the 1000+ range to avoid conflicts with Azure.Core

            var eventIds = new[]
            {
                AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent,
                AzureVoiceLiveEventSource.WebSocketConnectionClosedEvent,
                AzureVoiceLiveEventSource.WebSocketMessageSentEvent,
                AzureVoiceLiveEventSource.WebSocketMessageSentContentEvent,
                AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent,
                AzureVoiceLiveEventSource.WebSocketMessageReceivedEvent,
                AzureVoiceLiveEventSource.WebSocketMessageReceivedContentEvent,
                AzureVoiceLiveEventSource.WebSocketMessageReceivedContentTextEvent,
                AzureVoiceLiveEventSource.WebSocketMessageErrorEvent,
                AzureVoiceLiveEventSource.WebSocketMessageErrorContentEvent,
                AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent
            };

            // Assert all IDs are unique
            Assert.AreEqual(eventIds.Length, eventIds.Distinct().Count(), "All event IDs should be unique");

            // Assert all IDs are positive (simple range check)
            Assert.IsTrue(eventIds.All(id => id > 0), "All event IDs should be positive");
        }

        [LiveOnly] // Easier to run live than to fake the connection.
        [Test]
        public async Task Session_LogsMultipleOperations_InCorrectSequence()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };
            var client = GetLiveClient();

            var sessionOptions = new VoiceLiveSessionOptions()
            {
                Model = "gpt-4o"
            };

            var session = await client.StartSessionAsync(sessionOptions).ConfigureAwait(false);

            await session.CloseAsync(CancellationToken.None).ConfigureAwait(false);

#if NET6_0_OR_GREATER
            // Assert - verify the sequence of events
            var voiceLiveEvents = _capturedEvents
                .Where(e => e.EventSource.Name == "Azure-VoiceLive")
                .OrderBy(e => e.TimeStamp)
                .ToList();

            Assert.IsTrue(voiceLiveEvents.Count >= 3, $"Should have at least connection open, message sent, and connection close events, instead had {voiceLiveEvents.Count}");

            // First event should be connection open
            Assert.AreEqual(AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent, voiceLiveEvents[0].EventId, "First event should be connection open");

            // Should have message sent events
            Assert.IsTrue(voiceLiveEvents.Any(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentEvent), "Should have message sent event");

            // Last event should be connection close
            var lastEvent = voiceLiveEvents.Last();
            Assert.AreEqual(AzureVoiceLiveEventSource.WebSocketConnectionClosedEvent, lastEvent?.EventId, $"Last event should be connection close, but was {lastEvent?.EventName}");
#endif
        }
    }
}
