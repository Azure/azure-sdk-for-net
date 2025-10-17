// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Performance tests to ensure content logging doesn't significantly impact WebSocket operations.
    /// </summary>
    [TestFixture]
    public class ContentLoggingPerformanceTests : RecordedTestBase<VoiceLiveTestEnvironment>
    {
        public ContentLoggingPerformanceTests() : this(false) { }

        public ContentLoggingPerformanceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ContentLogger_WhenLoggingDisabled_HasMinimalOverhead()
        {
            // Arrange
            var optionsDisabled = new VoiceLiveClientOptions();
            optionsDisabled.Diagnostics.IsLoggingEnabled = false;

            var optionsEnabled = new VoiceLiveClientOptions();
            optionsEnabled.Diagnostics.IsLoggingEnabled = true;
            optionsEnabled.Diagnostics.IsLoggingContentEnabled = true;

            var loggerDisabled = new VoiceLiveWebSocketContentLogger(optionsDisabled.Diagnostics);
            var loggerEnabled = new VoiceLiveWebSocketContentLogger(optionsEnabled.Diagnostics);

            var testContent = "test message content"u8.ToArray();
            const int iterations = 1000;

            // Act & Measure - Disabled logging
            var stopwatchDisabled = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                loggerDisabled.LogSentMessage("conn1", testContent, isText: true);
            }
            stopwatchDisabled.Stop();

            // Act & Measure - Enabled logging
            using var listener = new NullEventListener(); // Consume events but don't process them
            var stopwatchEnabled = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                loggerEnabled.LogSentMessage("conn1", testContent, isText: true);
            }
            stopwatchEnabled.Stop();

            // Assert - Disabled should be significantly faster
            Assert.LessOrEqual(stopwatchDisabled.ElapsedMilliseconds, stopwatchEnabled.ElapsedMilliseconds * 0.1,
                "Disabled logging should have minimal overhead");

            // Both should be reasonably fast (less than 100ms for 1000 operations)
            Assert.Less(stopwatchDisabled.ElapsedMilliseconds, 100, "Disabled logging should be very fast");
            Assert.Less(stopwatchEnabled.ElapsedMilliseconds, 1000, "Enabled logging should still be reasonably fast");
        }

        [Test]
        public void ContentLogger_WithLargeContent_TruncatesEfficiently()
        {
            // Arrange
            var options = new VoiceLiveClientOptions();
            options.Diagnostics.IsLoggingEnabled = true;
            options.Diagnostics.IsLoggingContentEnabled = true;
            options.Diagnostics.LoggedContentSizeLimit = 1024; // 1KB limit

            var logger = new VoiceLiveWebSocketContentLogger(options.Diagnostics);

            // Create very large content (1MB)
            var largeContent = new byte[1024 * 1024];
            new Random().NextBytes(largeContent);

            const int iterations = 100;

            // Act & Measure
            using var listener = new NullEventListener();
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                logger.LogSentMessage("conn1", largeContent, isText: false);
            }
            stopwatch.Stop();

            // Assert - Should handle large content efficiently
            Assert.Less(stopwatch.ElapsedMilliseconds, 1000,
                "Large content truncation should be efficient (< 1 second for 100 operations with 1MB each)");
        }

        [Ignore("Very inconsistent when run in batch of tests")]
        [Test]
        public async Task SessionOperations_WithContentLogging_MaintainPerformance()
        {
            // This test ensures that adding content logging doesn't significantly slow down
            // core WebSocket operations

            // Arrange
            var optionsWithLogging = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true, IsLoggingContentEnabled = true }
            };
            var optionsWithoutLogging = new VoiceLiveClientOptions
            {
                Diagnostics = { IsLoggingEnabled = false, IsLoggingContentEnabled = false }
            };

            const int messageCount = 100;
            var testMessage = """{"type": "session.update", "session": {"voice": "alloy"}}""";
            var testData = BinaryData.FromString(testMessage);

            // Measure without logging
            var timeWithoutLogging = await MeasureSessionOperations(optionsWithoutLogging, messageCount, testData);

            // Measure with logging
            using var listener = new NullEventListener();
            var timeWithLogging = await MeasureSessionOperations(optionsWithLogging, messageCount, testData);

            // Assert - Logging shouldn't add more than 50% overhead
            var overhead = (timeWithLogging - timeWithoutLogging) / (double)timeWithoutLogging;
            Assert.LessOrEqual(overhead, 0.5, $"Content logging should add less than 50% overhead. Without: {timeWithoutLogging}ms, With: {timeWithLogging}ms, Overhead: {overhead:P}");
        }

        [Test]
        public void EventSource_EventCreation_IsEfficient()
        {
            // Test that EventSource event creation itself is efficient
            // when IsEnabled() returns false (common case in production)

            // Arrange
            var eventSource = AzureVoiceLiveEventSource.Singleton;
            const int iterations = 10000;

            // Act & Measure - When events are not enabled (common case)
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                // These should be very fast because IsEnabled() will return false
                eventSource.WebSocketConnectionOpening($"conn{i}", "wss://test.com");
                eventSource.WebSocketMessageSent($"conn{i}", "Text", 100);
            }
            stopwatch.Stop();

            // Assert - Should be very fast when events are disabled
            Assert.Less(stopwatch.ElapsedMilliseconds, 500,
                $"EventSource calls should be very fast when disabled ({iterations} calls in < 500ms)");
        }

        private async Task<long> MeasureSessionOperations(VoiceLiveClientOptions options, int messageCount, BinaryData testData)
        {
            var client = new VoiceLiveClient(new Uri("wss://test.example.com"), new AzureKeyCredential("test-key"), options);
            var session = new TestableVoiceLiveSession(client, new AzureKeyCredential("test-key"));
            var fakeWebSocket = new FakeWebSocket();
            session.SetWebSocket(fakeWebSocket);

            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < messageCount; i++)
            {
                await session.SendCommandAsync(testData, CancellationToken.None);
            }

            await session.CloseAsync(CancellationToken.None);

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
