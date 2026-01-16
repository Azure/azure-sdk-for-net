// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using Azure.Core.Diagnostics;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    [NonParallelizable]
    public class AzureEventSourceListenerTests
    {
        [Test]
        public void CallsCallbackWhenMessageIsLogged()
        {
            var invocations = new List<(EventWrittenEventArgs, string)>();
            using var _ = new AzureEventSourceListener(
                (args, s) =>
                {
                    invocations.Add((args, s));
                }, EventLevel.Verbose);

            AzureCoreEventSource.Singleton.Request("id", "GET", "http", "header", "Test-SDK");

            Assert.That(invocations.Count, Is.EqualTo(1));
            var singleInvocation = invocations.Single();

            Assert.That(singleInvocation.Item1.EventName, Is.EqualTo("Request"));
            Assert.That(singleInvocation.Item2, Is.Not.Null);
        }

        [Test]
        public void FiltersMessagesUsingLevel()
        {
            var warningInvocations = new List<(EventWrittenEventArgs, string)>();
            var verboseInvocations = new List<(EventWrittenEventArgs, string)>();
            using var verboseListener = new AzureEventSourceListener((args, s) => verboseInvocations.Add((args, s)), EventLevel.Verbose);
            using var warningListener = new AzureEventSourceListener((args, s) => warningInvocations.Add((args, s)), EventLevel.Warning);

            AzureCoreEventSource.Singleton.ErrorResponse("id", 500, "GET", "http", 5);
            AzureCoreEventSource.Singleton.Request("id", "GET", "http", "header", "Test-SDK");

            Assert.That(warningInvocations.Count, Is.EqualTo(1));
            var warningInvocation = warningInvocations.Single();
            Assert.That(warningInvocation.Item1.EventName, Is.EqualTo("ErrorResponse"));
            Assert.That(warningInvocation.Item2, Is.Not.Null);

            Assert.That(verboseInvocations.Count, Is.EqualTo(2));
            Assert.That(verboseInvocations.Any(c => c.Item1.EventName == "ErrorResponse"), Is.True);
            Assert.That(verboseInvocations.Any(c => c.Item1.EventName == "Request"), Is.True);
        }

        [Test]
        public void IgnoresEventCountersEvents()
        {
            var invocations = new List<(EventWrittenEventArgs, string)>();
            using var _ = new AzureEventSourceListener(
                (args, s) =>
                {
                    invocations.Add((args, s));
                }, EventLevel.Verbose);

            TestSource.Log.Write("EventCounters");

            Assert.That(invocations.Count, Is.EqualTo(0));
        }

        [Test]
        public void FormatsUsingMessageWhenAvailable()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithMessage("a message"));
            Assert.That(message, Is.EqualTo("Logging a message"));
        }

        [Test]
        public void FormatsByteArrays()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithByteArray(new byte[] { 0, 1, 233 }));
            Assert.That(message, Is.EqualTo("Logging 0001E9"));
        }

        [Test]
        public void FormatsLargeByteArrays()
        {
            byte[] largeArray = new byte[64];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(largeArray);

            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithByteArray(largeArray));
            Assert.That(message, Is.EqualTo($"Logging {string.Join("", largeArray.Select(b => b.ToString("X2")))}"));
        }

        [Test]
        public void FormatsAsKeyValuesIfNoMessage()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithoutMessage("a message", 5));
            Assert.That(message, Is.EqualTo("LogWithoutMessage" + Environment.NewLine +
                            "message = a message" + Environment.NewLine +
                            "other = 5"));
        }

        [Test]
        public void FormatsUnformattableMessageAsKeyValues()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogUnformattableMessage("a message"));
            Assert.That(message, Is.EqualTo("LogUnformattableMessage" + Environment.NewLine +
                            nameof(e.Message) + " = Logging {1}" + Environment.NewLine +
                            "payload = a message"));
        }

        private static (EventWrittenEventArgs EventArgs, string Formatted) ExpectSingleEvent(Action logDelegate)
        {
            var invocations = new List<(EventWrittenEventArgs, string)>();
            using var _ = new AzureEventSourceListener(
                (args, s) =>
                {
                    invocations.Add((args, s));
                }, EventLevel.Verbose);
            logDelegate();
            Assert.That(invocations.Count, Is.EqualTo(1));
            return invocations.Single();
        }

        private class TestSource : EventSource
        {
            internal static TestSource Log { get; } = new TestSource();

            private TestSource() : base("Test-source", EventSourceSettings.Default, "AzureEventSource", "true")
            {
            }

            [Event(1, Message = "Logging {0}", Level = EventLevel.Critical)]
            public void LogWithMessage(string message)
            {
                WriteEvent(1, message);
            }

            [Event(2, Level = EventLevel.Critical)]
            public void LogWithoutMessage(string message, int other)
            {
                WriteEvent(2, message, other);
            }

            [Event(3, Message = "Logging {0}", Level = EventLevel.Critical)]
            public void LogWithByteArray(byte[] b)
            {
                WriteEvent(3, b);
            }

            [Event(4, Message = "Logging {1}", Level = EventLevel.Critical)]
            public void LogUnformattableMessage(string payload)
            {
                WriteEvent(4, payload);
            }
        }
    }
}
