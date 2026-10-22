// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class GenAiTruncationTests
    {
        /// <summary>
        /// A payload larger than the 256 KiB GenAI truncation limit and smaller than the 4 MiB GenAI messages limit.
        /// </summary>
        private const int LargePayloadLength = 300_000;

        private const int GenAiMessagesLimit = 4 * 1024 * 1024;

        private static readonly string s_largePayload = new string('x', LargePayloadLength);

        /// <summary>
        /// A non-uniform payload larger than the 4 MiB GenAI messages limit, used to verify the retained prefix.
        /// </summary>
        private static readonly string s_oversizedMessagesPayload = string.Concat(Enumerable.Repeat("abc", (GenAiMessagesLimit + 1000) / 3));

        public static IEnumerable<object[]> GenAiMessageKeys => new[]
        {
            new object[] { "gen_ai.input.messages" },
            new object[] { "gen_ai.output.messages" },
        };

        public static IEnumerable<object[]> GenAiNonMessageKeys => new[]
        {
            new object[] { "gen_ai.system_instructions" },
            new object[] { "gen_ai.tool.definitions" },
            new object[] { "gen_ai.tool.call.arguments" },
            new object[] { "gen_ai.tool.call.result" },
            new object[] { "gen_ai.evaluation.explanation" },
        };

        static GenAiTruncationTests()
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            Activity.ForceDefaultIdFormat = true;

            var listener = new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            };

            ActivitySource.AddActivityListener(listener);
        }

        [Fact]
        public void GenAiPropertyMaxValueLengths_HasExpectedLimits()
        {
            Assert.Equal(8 * 1024, SchemaConstants.KVP_MaxValueLength);
            Assert.Equal(256 * 1024, SchemaConstants.GenAi_Properties_MaxValueLength);
            Assert.Equal(4 * 1024 * 1024, SchemaConstants.GenAi_Messages_MaxValueLength);

            Assert.Equal(7, SchemaConstants.GenAiPropertyMaxValueLengths.Count);
            foreach (var key in GenAiMessageKeys.Select(x => (string)x[0]))
            {
                Assert.Equal(SchemaConstants.GenAi_Messages_MaxValueLength, SchemaConstants.GenAiPropertyMaxValueLengths[key]);
            }

            foreach (var key in GenAiNonMessageKeys.Select(x => (string)x[0]))
            {
                Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, SchemaConstants.GenAiPropertyMaxValueLengths[key]);
            }

            Assert.Equal(SchemaConstants.KVP_MaxValueLength, SchemaConstants.GetPropertyMaxValueLength("custom.attribute", SchemaConstants.KVP_MaxValueLength));
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, SchemaConstants.GetPropertyMaxValueLength("GEN_AI.INPUT.MESSAGES", SchemaConstants.KVP_MaxValueLength));
        }

        [Theory]
        [InlineData("gen_ai.input.messages", SchemaConstants.GenAi_Messages_MaxValueLength)]
        [InlineData("gen_ai.output.messages", SchemaConstants.GenAi_Messages_MaxValueLength)]
        [InlineData("gen_ai.tool.definitions", SchemaConstants.GenAi_Properties_MaxValueLength)]
        [InlineData("custom.attribute", SchemaConstants.KVP_MaxValueLength)]
        public void Properties_AreTruncatedAtTheirLimitBoundary(string propertyKey, int limit)
        {
            var baseValue = new string('b', limit + 1);

            foreach (var length in new[] { limit - 1, limit, limit + 1 })
            {
                IDictionary<string, string> destination = new Dictionary<string, string>();

                TraceHelper.AddKvpToDictionary(destination, propertyKey, baseValue.Substring(0, length));

                Assert.True(destination.TryGetValue(propertyKey, out var value));
                Assert.Equal(Math.Min(length, limit), value!.Length);
            }
        }

        [Theory]
        [MemberData(nameof(GenAiNonMessageKeys))]
        public void GenAiProperties_AreTruncatedTo256KB_InAddPropertiesToTelemetry(string propertyKey)
        {
            var value = AddPropertiesToTelemetry(propertyKey, s_largePayload);

            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreNotTruncatedBelow4MB_InAddPropertiesToTelemetry(string propertyKey)
        {
            var value = AddPropertiesToTelemetry(propertyKey, s_largePayload);

            Assert.Equal(s_largePayload, value);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreTruncatedTo4MB_InAddPropertiesToTelemetry(string propertyKey)
        {
            var value = AddPropertiesToTelemetry(propertyKey, s_oversizedMessagesPayload);

            AssertTruncatedTo4MB(value);
        }

        [Theory]
        [MemberData(nameof(GenAiNonMessageKeys))]
        public void GenAiProperties_AreTruncatedTo256KB_InAddKvpToDictionary_WithStringOverload(string propertyKey)
        {
            IDictionary<string, string> destination = new Dictionary<string, string>();

            TraceHelper.AddKvpToDictionary(destination, propertyKey, s_largePayload);

            Assert.True(destination.TryGetValue(propertyKey, out var value));
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreTruncatedTo4MB_InAddKvpToDictionary_WithStringOverload(string propertyKey)
        {
            IDictionary<string, string> destination = new Dictionary<string, string>();

            TraceHelper.AddKvpToDictionary(destination, propertyKey, s_largePayload);
            TraceHelper.AddKvpToDictionary(destination, propertyKey + ".oversized", s_oversizedMessagesPayload);

            Assert.True(destination.TryGetValue(propertyKey, out var value));
            Assert.Equal(s_largePayload, value);

            // Only the exact GenAI messages keys receive the 4 MiB limit.
            Assert.True(destination.TryGetValue(propertyKey + ".oversized", out var otherValue));
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, otherValue!.Length);

            destination.Clear();
            TraceHelper.AddKvpToDictionary(destination, propertyKey, s_oversizedMessagesPayload);
            Assert.True(destination.TryGetValue(propertyKey, out value));
            AssertTruncatedTo4MB(value!);
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InAddPropertiesToTelemetry()
        {
            var value = AddPropertiesToTelemetry("regular.property", s_largePayload);

            Assert.Equal(SchemaConstants.KVP_MaxValueLength, value.Length);
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InAddKvpToDictionary_WithStringOverload()
        {
            IDictionary<string, string> destination = new Dictionary<string, string>();

            TraceHelper.AddKvpToDictionary(destination, "regular.property", s_largePayload);

            Assert.True(destination.TryGetValue("regular.property", out var value));
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, value!.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiNonMessageKeys))]
        public void GenAiProperties_AreTruncatedTo256KB_InLogRecordAttributes(string propertyKey)
        {
            var value = GetLogRecordProperty(propertyKey, s_largePayload);

            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreTruncatedTo4MB_InLogRecordAttributes(string propertyKey)
        {
            Assert.Equal(s_largePayload, GetLogRecordProperty(propertyKey, s_largePayload));
            AssertTruncatedTo4MB(GetLogRecordProperty(propertyKey, s_oversizedMessagesPayload));
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InLogRecordAttributes()
        {
            var value = GetLogRecordProperty("regular.property", s_largePayload);

            Assert.Equal(SchemaConstants.MessageData_Properties_MaxValueLength, value.Length);
        }

        [Theory]
        [InlineData("gen_ai.input.messages", LargePayloadLength)]
        [InlineData("gen_ai.output.messages", LargePayloadLength)]
        [InlineData("gen_ai.system_instructions", SchemaConstants.GenAi_Properties_MaxValueLength)]
        [InlineData("regular.property", SchemaConstants.MessageData_Properties_MaxValueLength)]
        public void Properties_AreTruncated_InLogScopes(string propertyKey, int expectedLength)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(GenAiTruncationTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<GenAiTruncationTests>();

            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(propertyKey, s_largePayload),
            }))
            {
                logger.LogInformation("test message");
            }

            Assert.Single(logRecords);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out _, out _, out _, out _);

            Assert.True(properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in the properties dictionary.");
            Assert.Equal(expectedLength, value!.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiNonMessageKeys))]
        public void GenAiProperties_AreTruncatedTo256KB_InActivityCustomDimensions(string propertyKey)
        {
            var value = GetRemoteDependencyProperty(propertyKey, s_largePayload);

            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreTruncatedTo4MB_InActivityCustomDimensions(string propertyKey)
        {
            Assert.Equal(s_largePayload, GetRemoteDependencyProperty(propertyKey, s_largePayload));
            AssertTruncatedTo4MB(GetRemoteDependencyProperty(propertyKey, s_oversizedMessagesPayload));
        }

        [Theory]
        [MemberData(nameof(GenAiNonMessageKeys))]
        public void GenAiProperties_AreTruncatedTo256KB_InRequestDataCustomDimensions(string propertyKey)
        {
            var value = GetRequestProperty(propertyKey, s_largePayload);

            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value.Length);
        }

        [Theory]
        [MemberData(nameof(GenAiMessageKeys))]
        public void GenAiMessages_AreTruncatedTo4MB_InRequestDataCustomDimensions(string propertyKey)
        {
            Assert.Equal(s_largePayload, GetRequestProperty(propertyKey, s_largePayload));
            AssertTruncatedTo4MB(GetRequestProperty(propertyKey, s_oversizedMessagesPayload));
        }

        [Theory]
        [InlineData("gen_ai.input.messages", LargePayloadLength)]
        [InlineData("gen_ai.output.messages", LargePayloadLength)]
        [InlineData("gen_ai.tool.call.result", SchemaConstants.GenAi_Properties_MaxValueLength)]
        [InlineData("regular.property", SchemaConstants.KVP_MaxValueLength)]
        public void Properties_AreTruncated_InActivityEvents(string propertyKey, int expectedLength)
        {
            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            using var activity = activitySource.StartActivity("TestActivity", ActivityKind.Client);

            Assert.NotNull(activity);
            activity.AddEvent(new ActivityEvent("gen_ai.client.inference.operation.details", tags: new ActivityTagsCollection
            {
                { propertyKey, s_largePayload },
            }));
            activity.Stop();

            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);

            var messageData = telemetryItems.Select(x => x.Data.BaseData).OfType<MessageData>().Single();
            Assert.True(messageData.Properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in trace custom dimensions.");
            Assert.Equal(expectedLength, value!.Length);
        }

        [Fact]
        public void Properties_AreTruncatedPerTier_InMixedActivity()
        {
            var value = new string('z', 1024 * 1024);
            var tags = new[]
            {
                new KeyValuePair<string, object?>("gen_ai.input.messages", value),
                new KeyValuePair<string, object?>("gen_ai.output.messages", value),
                new KeyValuePair<string, object?>("gen_ai.system_instructions", value),
                new KeyValuePair<string, object?>("custom.attribute", value),
            };

            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            using var activity = activitySource.StartActivity("TestActivity", ActivityKind.Client, parentContext: default, tags: tags);

            Assert.NotNull(activity);
            activity.Stop();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.Equal(value.Length, remoteDependencyData.Properties["gen_ai.input.messages"].Length);
            Assert.Equal(value.Length, remoteDependencyData.Properties["gen_ai.output.messages"].Length);
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, remoteDependencyData.Properties["gen_ai.system_instructions"].Length);
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, remoteDependencyData.Properties["custom.attribute"].Length);
        }

        [Fact]
        public void GenAiMessages_WithMultimodalBlob_AreKeptIntact_ThroughSerialization()
        {
            var imageBytes = new byte[1024 * 1024];
            new Random(42).NextBytes(imageBytes);
            var blob = Convert.ToBase64String(imageBytes);

            var messages = new StringBuilder()
                .Append("[{\"role\":\"user\",\"parts\":[")
                .Append("{\"type\":\"text\",\"content\":\"Describe this image\"},")
                .Append("{\"type\":\"blob\",\"modality\":\"image\",\"mime_type\":\"image/png\",\"content\":\"").Append(blob).Append("\"}")
                .Append("]}]")
                .ToString();

            Assert.True(messages.Length > SchemaConstants.GenAi_Properties_MaxValueLength);
            Assert.True(messages.Length < SchemaConstants.GenAi_Messages_MaxValueLength);

            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            using var activity = activitySource.StartActivity(
                "TestActivity",
                ActivityKind.Client,
                parentContext: default,
                tags: new[]
                {
                    new KeyValuePair<string, object?>("gen_ai.input.messages", messages),
                    new KeyValuePair<string, object?>("gen_ai.output.messages", messages),
                });

            Assert.NotNull(activity);
            activity.Stop();

            var (telemetryItems, _) = TraceHelper.OtelToAzureMonitorTrace(new Batch<Activity>(new Activity[] { activity }, 1), null, "instrumentationKey", 1.0f);
            var serialized = HttpPipelineHelper.GetSerializedContent(telemetryItems);

            using var document = JsonDocument.Parse(serialized);
            var properties = document.RootElement.GetProperty("data").GetProperty("baseData").GetProperty("properties");

            foreach (var key in new[] { "gen_ai.input.messages", "gen_ai.output.messages" })
            {
                var value = properties.GetProperty(key).GetString();
                Assert.Equal(messages, value);

                using var messagesDocument = JsonDocument.Parse(value!);
                var blobPart = messagesDocument.RootElement[0].GetProperty("parts")[1];
                Assert.Equal(blob, blobPart.GetProperty("content").GetString());
            }
        }

        private static void AssertTruncatedTo4MB(string value)
        {
            Assert.Equal(SchemaConstants.GenAi_Messages_MaxValueLength, value.Length);
            Assert.Equal(s_oversizedMessagesPayload.Substring(0, SchemaConstants.GenAi_Messages_MaxValueLength), value);
        }

        private static string AddPropertiesToTelemetry(string propertyKey, string payload)
        {
            IDictionary<string, string> destination = new Dictionary<string, string>();
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(propertyKey, payload));

            TraceHelper.AddPropertiesToTelemetry(destination, ref tagObjects);

            Assert.True(destination.TryGetValue(propertyKey, out var value));
            return value!;
        }

        private static string GetLogRecordProperty(string propertyKey, string payload)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(GenAiTruncationTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<GenAiTruncationTests>();

            var state = new List<KeyValuePair<string, object?>>
            {
                new(propertyKey, payload),
            };
            logger.Log(LogLevel.Information, 0, state, null, (s, e) => "test message");

            Assert.Single(logRecords);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out _, out _, out _, out _);

            Assert.True(properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in the properties dictionary.");
            return value!;
        }

        private static string GetRemoteDependencyProperty(string propertyKey, string payload)
        {
            using var activity = StartAndStopActivity(ActivityKind.Client, propertyKey, payload);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            Assert.True(remoteDependencyData.Properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in dependency custom dimensions.");
            return value!;
        }

        private static string GetRequestProperty(string propertyKey, string payload)
        {
            using var activity = StartAndStopActivity(ActivityKind.Server, propertyKey, payload);

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            Assert.True(requestData.Properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in request custom dimensions.");
            return value!;
        }

        private static Activity StartAndStopActivity(ActivityKind kind, string propertyKey, string payload)
        {
            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            var activity = activitySource.StartActivity(
                "TestActivity",
                kind,
                parentContext: default,
                tags: new[] { new KeyValuePair<string, object?>(propertyKey, payload) });

            Assert.NotNull(activity);
            activity.Stop();
            return activity;
        }
    }
}
