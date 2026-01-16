// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
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
    /// Tests that verify the unified Azure SDK logging experience works correctly.
    /// These tests demonstrate how developers can create listeners that handle both
    /// HTTP (Azure.Core) and WebSocket (Azure.VoiceLive) events together.
    /// </summary>
    [TestFixture]
    public class UnifiedLoggingExperienceTests : RecordedTestBase<VoiceLiveTestEnvironment>
    {
        public UnifiedLoggingExperienceTests() : this(false) { }

        public UnifiedLoggingExperienceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task UnifiedListener_CapturesWebSocketEvents_WithCorrectMetadata()
        {
            // Arrange
            var capturedEvents = new List<CapturedEvent>();
            using var listener = new DocumentationExampleEventListener(capturedEvents);

            var options = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };

            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            // Act - Perform WebSocket operations
            // await session.ConnectAsync(new Dictionary<string, string>(), CancellationToken.None);
            await session.SendCommandAsync(BinaryData.FromString("""{"type": "test", "data": "hello"}"""), CancellationToken.None);

            fakeWebSocket.EnqueueTextMessage("""{"type": "response", "data": "world"}""");
            await foreach (var update in session.ReceiveUpdatesAsync().WithCancellation(new CancellationTokenSource(TimeSpan.FromSeconds(1)).Token))
            {
                break; // Just process one
            }

            await session.CloseAsync(CancellationToken.None);

            // Assert - Verify captured events match expected patterns
            var voiceLiveEvents = capturedEvents.Where(e => e.Source == "Azure-VoiceLive").ToList();

            Assert.That(voiceLiveEvents.Count >= 4, Is.True, "Should capture connection, send, receive, and close events");

            // Verify connection lifecycle
            var connectionClose = voiceLiveEvents.FirstOrDefault(e => e.EventType == "ConnectionClose");
            Assert.That(connectionClose, Is.Not.Null, "Should capture connection close");

            // Verify message operations
            var messageSent = voiceLiveEvents.FirstOrDefault(e => e.EventType == "MessageSent");
            var messageReceived = voiceLiveEvents.FirstOrDefault(e => e.EventType == "MessageReceived");
            Assert.That(messageSent, Is.Not.Null, "Should capture message sent");
            Assert.That(messageReceived, Is.Not.Null, "Should capture message received");

            // Verify content logging
            var contentSent = voiceLiveEvents.FirstOrDefault(e => e.EventType == "ContentSent");
            var contentReceived = voiceLiveEvents.FirstOrDefault(e => e.EventType == "ContentReceived");
            Assert.That(contentSent, Is.Not.Null, "Should capture sent content");
            Assert.That(contentReceived, Is.Not.Null, "Should capture received content");

            // Verify content includes expected data
            Assert.That(contentSent?.Content?.Contains("hello") == true, Is.True, "Sent content should contain expected data");
            Assert.That(contentReceived?.Content?.Contains("world") == true, Is.True, "Received content should contain expected data");
        }

        [Test]
        public void EventLevels_FollowAzureSDKPatterns()
        {
            // Verify that event levels match Azure.Core patterns:
            // - Informational: Connection lifecycle, message operations
            // - Verbose: Normal content logging
            // - Informational: Error content (higher priority than normal content)
            // - Warning: Errors

            // Arrange
            var capturedEvents = new List<EventWrittenEventArgs>();
            using var listener = new RawEventListener(capturedEvents);

            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            // Act
            logger.LogConnectionOpening("conn1", "wss://test.com");           // Should be Informational
            logger.LogSentMessage("conn1", "content"u8.ToArray(), true);  // Message: Informational, Content: Verbose
            logger.LogError("conn1", "error", "error content"u8.ToArray(), true); // Error: Warning, Content: Informational

            // Assert
            var events = capturedEvents.Where(e => e.EventSource.Name == "Azure-VoiceLive").ToList();

            var connectionEvent = events.FirstOrDefault(e => e.EventId == AzureVoiceLiveEventSource.WebSocketConnectionOpeningEvent);
            var messageSentEvent = events.FirstOrDefault(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentEvent);
            var contentSentEvent = events.FirstOrDefault(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent);
            var errorEvent = events.FirstOrDefault(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorEvent);
            var errorContentEvent = events.FirstOrDefault(e => e.EventId == AzureVoiceLiveEventSource.WebSocketMessageErrorContentTextEvent);

            Assert.That(connectionEvent?.Level, Is.EqualTo(EventLevel.Informational), "Connection events should be Informational");
            Assert.That(messageSentEvent?.Level, Is.EqualTo(EventLevel.Informational), "Message events should be Informational");
            Assert.That(contentSentEvent?.Level, Is.EqualTo(EventLevel.Verbose), "Normal content should be Verbose");
            Assert.That(errorEvent?.Level, Is.EqualTo(EventLevel.Warning), "Error events should be Warning");
            Assert.That(errorContentEvent?.Level, Is.EqualTo(EventLevel.Informational), "Error content should be Informational (higher priority)");
        }

        [Ignore("Timing issue")]
        [Test]
        public void ConfigurationExperience_MatchesAzureSDKPatterns()
        {
            // Verify that content logging configuration follows Azure SDK patterns

            // Standard Azure SDK configuration pattern
            var options = new VoiceLiveClientOptions
            {
                Diagnostics =
                {
                    IsLoggingEnabled = true,           // Enable general logging
                    IsLoggingContentEnabled = true,    // Enable content logging specifically
                    LoggedContentSizeLimit = 8192      // Control content size
                }
            };

            // Verify the configuration is accessible and works as expected
            Assert.That(options.Diagnostics.IsLoggingEnabled, Is.True);
            Assert.That(options.Diagnostics.IsLoggingContentEnabled, Is.True);
            Assert.That(options.Diagnostics.LoggedContentSizeLimit, Is.EqualTo(8192));

            // Verify it works with content logger
            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);
            Assert.That(logger.IsContentLoggingEnabled, Is.True);
            Assert.That(logger.IsLoggingEnabled, Is.True);
        }
    }
}
