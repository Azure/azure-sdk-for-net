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

            Assert.AreEqual(1, invocations.Count);
            var singleInvocation = invocations.Single();

            Assert.AreEqual("Request", singleInvocation.Item1.EventName);
            Assert.NotNull(singleInvocation.Item2);
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

            Assert.AreEqual(1, warningInvocations.Count);
            var warningInvocation = warningInvocations.Single();
            Assert.AreEqual("ErrorResponse", warningInvocation.Item1.EventName);
            Assert.NotNull(warningInvocation.Item2);

            Assert.AreEqual(2, verboseInvocations.Count);
            Assert.True(verboseInvocations.Any(c=>c.Item1.EventName == "ErrorResponse"));
            Assert.True(verboseInvocations.Any(c=>c.Item1.EventName == "Request"));
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

            Assert.AreEqual(0, invocations.Count);
        }

        [Test]
        public void FormatsUsingMessageWhenAvailable()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithMessage("a message"));
            Assert.AreEqual("Logging a message", message);
        }

        [Test]
        public void FormatsByteArrays()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithByteArray(new byte[] { 0, 1, 233 }));
            Assert.AreEqual("Logging 0001E9", message);
        }

        [Test]
        public void FormatsLargeByteArrays()
        {
            byte[] largeArray = new byte[64];
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(largeArray);

            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithByteArray(largeArray));
            Assert.AreEqual($"Logging {string.Join("", largeArray.Select(b => b.ToString("X2")))}", message);
        }

        [Test]
        public void FormatsAsKeyValuesIfNoMessage()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogWithoutMessage("a message", 5));
            Assert.AreEqual("LogWithoutMessage" + Environment.NewLine +
                            "message = a message" + Environment.NewLine +
                            "other = 5", message);
        }

        [Test]
        public void FormatsUnformattableMessageAsKeyValues()
        {
            (EventWrittenEventArgs e, string message) = ExpectSingleEvent(() => TestSource.Log.LogUnformattableMessage("a message"));
            Assert.AreEqual("LogUnformattableMessage" + Environment.NewLine +
                            nameof(e.Message) + " = Logging {1}" + Environment.NewLine +
                            "payload = a message", message);
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
            Assert.AreEqual(1, invocations.Count);
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
