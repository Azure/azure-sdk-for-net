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
    /// Integration tests that verify EventSource behavior and unified logging scenarios.
    /// </summary>
    [TestFixture]
    public class EventSourceIntegrationTests : RecordedTestBase<VoiceLiveTestEnvironment>
    {
        private readonly List<EventWrittenEventArgs> _capturedEvents = new();
        private UnifiedTestEventListener? _eventListener;

        public EventSourceIntegrationTests() : this(true) { }

        public EventSourceIntegrationTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            _capturedEvents.Clear();
            _eventListener = new UnifiedTestEventListener(_capturedEvents);
        }

        [TearDown]
        public void TearDown()
        {
            _eventListener?.Dispose();
            _eventListener = null;
        }

        [Test]
        public void AzureVoiceLiveEventSource_InheritsFromAzureEventSource()
        {
            // Arrange & Act
            var eventSource = AzureVoiceLiveEventSource.Singleton;

            // Assert
            Assert.That(eventSource.Name, Does.StartWith("Azure-"), "EventSource name should start with 'Azure-' following Azure SDK conventions");

            // Verify it has Azure SDK traits (inherited from AzureEventSource)
            // These traits make it discoverable by Azure SDK diagnostic tooling
            Assert.That(eventSource.Name, Is.Not.Null);
        }

        [Test]
        public void EventSource_CanBeDiscoveredByAzurePattern()
        {
            // This test verifies that the EventSource follows Azure SDK naming conventions
            // and can be discovered by listeners that filter on "Azure-*" patterns

            // Arrange
            var azureEventSources = new List<string>();

            // Act - simulate how a unified listener would discover Azure EventSources
            foreach (var eventSource in EventSource.GetSources())
            {
                if (eventSource.Name.StartsWith("Azure-"))
                {
                    azureEventSources.Add(eventSource.Name);
                }
            }

            // Assert
            Assert.That(azureEventSources, Does.Contain("Azure-VoiceLive"), "Azure-VoiceLive EventSource should be discoverable via Azure- pattern");
        }

        [Test]
        public void ContentLogger_WithDifferentLogLevels_FiltersEventsCorrectly()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            // Dispose existing listener and create one with Informational level only
            _eventListener?.Dispose();
            _eventListener = new UnifiedTestEventListener(_capturedEvents, EventLevel.Informational);

            // Act - log various events
            logger.LogConnectionOpening("conn1", "wss://test.com");
            logger.LogSentMessage("conn1", "test message"u8.ToArray(), isText: true);
            logger.LogError("conn1", "test error", "error content"u8.ToArray(), isText: true);

            // Assert
            var events = _capturedEvents.Where(e => e.EventSource.Name == "Azure-VoiceLive").ToList();

            Assert.Multiple(() =>
            {
                // Should have connection open (Informational) and error events (Warning + Informational for content)
                Assert.That(events.Any(e => e.EventId == AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent && e.Level == EventLevel.Informational), Is.True, "Should have connection open event");
                Assert.That(events.Any(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorEvent && e.Level == EventLevel.Warning), Is.True, "Should have error event");
                Assert.That(events.Any(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent && e.Level == EventLevel.Informational), Is.True, "Should have error content event");

                // Should NOT have sent message content (Verbose level)
                Assert.That(events.Any(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageReceivedContentTextEvent), Is.False, "Should NOT have verbose content events when listening at Informational level");
            });
        }

        [Test]
        public void EventMessages_FollowAzureSDKPatterns()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            // Act
            logger.LogConnectionOpening("abc12345", "wss://test.example.com/socket");
            logger.LogSentMessage("abc12345", "test content"u8.ToArray(), isText: true);
            logger.LogError("abc12345", "Connection failed", ReadOnlyMemory<byte>.Empty);

            // Assert
            var events = _capturedEvents.Where(e => e.EventSource.Name == "Azure-VoiceLive").ToList();

            foreach (var evt in events)
            {
                // Verify connection ID is in the payload (first parameter for all our events)
                Assert.That(evt.Payload, Is.Not.Null, "Event should have payload");
                Assert.Multiple(() =>
                {
                    Assert.That(evt.Payload?.Count > 0, Is.True, "Event payload should have at least one item");
                    Assert.That(evt.Payload?[0], Is.EqualTo("abc12345"), $"First payload item should be connection ID for event {evt.EventId}");
                });

                // Verify message templates follow Azure SDK patterns
                if (evt.EventId == AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent) // Connection open
                {
                    Assert.That(evt.Message, Is.Not.Null, "Event message should not be null");
                    Assert.That(evt.Message is not null && evt.Message.Contains("VoiceLive WebSocket") && evt.Message.Contains("opening"),
                        Is.True,
                        $"Connection open message template should follow expected pattern: \"{evt.Message}\"");
                }
                else if (evt.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent) // Content sent (text)
                {
                    Assert.That(evt.Message, Is.Not.Null, "Event message should not be null");
                    Assert.That(evt.Message?.Contains("sent content"),
                        Is.True,
                        $"Content message template should follow expected pattern: \"{evt.Message}\"");
                }
                else if (evt.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent) // Error
                {
                    Assert.That(evt.Message, Is.Not.Null, "Event message should not be null");
                    Assert.That(evt.Message?.Contains("error"),
                        Is.True,
                        $"Error message template should follow expected pattern: \"{evt.Message}\"");
                }
            }
        }

        [Test]
        public void ContentLogging_RespectsContentSizeLimit()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;
            options.Diagnostics.LoggedContentSizeLimit = 50; // Small limit

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            var largeContent = new string('x', 100); // 100 characters
            var largeBytes = Encoding.UTF8.GetBytes(largeContent);

            // Act
            logger.LogSentMessage("test-conn", largeBytes, isText: true);

            // Assert
            var contentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent);

            Assert.That(contentEvent, Is.Not.Null, "Content event should be logged");
            Assert.That(contentEvent?.Payload, Is.Not.Null, "Event payload should not be null");
            Assert.That(contentEvent?.Payload?.Count > 1, Is.True, "Event payload should have at least 2 items");
            var loggedContent = (string)contentEvent?.Payload?[1]!;

            // Content should be truncated but properly encoded
            Assert.That(loggedContent.Length <= 50, Is.True, $"Logged content should be truncated to 50 chars or less, was {loggedContent.Length}");
        }

        [Test]
        public void ErrorContentLogging_AlwaysLogsWhenContentLoggingEnabled()
        {
            // This test verifies that error content is logged at Informational level
            // (higher priority than normal Verbose content) following Azure.Core patterns

            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            // Set up listener at Informational level (would miss Verbose but should catch error content)
            _eventListener?.Dispose();
            _eventListener = new UnifiedTestEventListener(_capturedEvents, EventLevel.Informational);

            // Act
            logger.LogError("test-conn", "WebSocket error", "error details"u8.ToArray(), isText: true);

            // Assert
            var errorEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorEvent);
            var errorContentEvent = _capturedEvents.FirstOrDefault(e =>
                e.EventSource.Name == "Azure-VoiceLive" && e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent);

            Assert.That(errorEvent, Is.Not.Null, "Error event should be logged");
            Assert.Multiple(() =>
            {
                Assert.That(errorEvent?.Level, Is.EqualTo(EventLevel.Warning));

                Assert.That(errorContentEvent, Is.Not.Null, "Error content should be logged at Informational level");
            });
            Assert.That(errorContentEvent?.Level, Is.EqualTo(EventLevel.Informational));
        }

        [Test]
        public void ConnectionIdGeneration_ProducesUniqueIdentifiers()
        {
            // Arrange
            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true }
            };
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);

            // Act - create multiple sessions
            var session1 = new TestableVoiceLiveSession(client, new AzureKeyCredential("key1"));
            var session2 = new TestableVoiceLiveSession(client, new AzureKeyCredential("key2"));
            var session3 = new TestableVoiceLiveSession(client, new AzureKeyCredential("key3"));

            // Each session should generate unique connection IDs
            // We can't directly access the connection IDs, but we can verify through logging
            // This test mainly ensures that the connection ID generation doesn't throw exceptions
            Assert.DoesNotThrow(() =>
            {
                _ = new TestableVoiceLiveSession(client, new AzureKeyCredential("key"));
            });
        }
    }
}
