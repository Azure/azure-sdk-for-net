// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        /// A payload larger than the 256 KB GenAI truncation limit to verify truncation occurs.
        /// </summary>
        private const int LargePayloadLength = 300_000;

        private static readonly string s_largePayload = new string('x', LargePayloadLength);

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

        [Theory]
        [InlineData("gen_ai.input.messages")]
        [InlineData("gen_ai.output.messages")]
        [InlineData("gen_ai.system_instructions")]
        [InlineData("gen_ai.tool.definitions")]
        [InlineData("gen_ai.tool.call.arguments")]
        [InlineData("gen_ai.tool.call.result")]
        [InlineData("gen_ai.evaluation.explanation")]
        public void GenAiProperties_AreTruncatedTo256KB_InAddPropertiesToTelemetry(string propertyKey)
        {
            // Arrange
            IDictionary<string, string> destination = new Dictionary<string, string>();
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>(propertyKey, s_largePayload));

            // Act
            TraceHelper.AddPropertiesToTelemetry(destination, ref tagObjects);

            // Assert
            Assert.True(destination.TryGetValue(propertyKey, out var value));
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }

        [Theory]
        [InlineData("gen_ai.input.messages")]
        [InlineData("gen_ai.output.messages")]
        [InlineData("gen_ai.system_instructions")]
        [InlineData("gen_ai.tool.definitions")]
        [InlineData("gen_ai.tool.call.arguments")]
        [InlineData("gen_ai.tool.call.result")]
        [InlineData("gen_ai.evaluation.explanation")]
        public void GenAiProperties_AreTruncatedTo256KB_InAddKvpToDictionary_WithStringOverload(string propertyKey)
        {
            // Arrange
            IDictionary<string, string> destination = new Dictionary<string, string>();

            // Act
            TraceHelper.AddKvpToDictionary(destination, propertyKey, s_largePayload);

            // Assert
            Assert.True(destination.TryGetValue(propertyKey, out var value));
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InAddPropertiesToTelemetry()
        {
            // Arrange
            IDictionary<string, string> destination = new Dictionary<string, string>();
            var tagObjects = AzMonList.Initialize();
            AzMonList.Add(ref tagObjects, new KeyValuePair<string, object?>("regular.property", s_largePayload));

            // Act
            TraceHelper.AddPropertiesToTelemetry(destination, ref tagObjects);

            // Assert
            Assert.True(destination.TryGetValue("regular.property", out var value));
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, value!.Length);
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InAddKvpToDictionary_WithStringOverload()
        {
            // Arrange
            IDictionary<string, string> destination = new Dictionary<string, string>();

            // Act
            TraceHelper.AddKvpToDictionary(destination, "regular.property", s_largePayload);

            // Assert
            Assert.True(destination.TryGetValue("regular.property", out var value));
            Assert.Equal(SchemaConstants.KVP_MaxValueLength, value!.Length);
        }

        [Theory]
        [InlineData("gen_ai.input.messages")]
        [InlineData("gen_ai.output.messages")]
        [InlineData("gen_ai.system_instructions")]
        [InlineData("gen_ai.tool.definitions")]
        [InlineData("gen_ai.tool.call.arguments")]
        [InlineData("gen_ai.tool.call.result")]
        [InlineData("gen_ai.evaluation.explanation")]
        public void GenAiProperties_AreTruncatedTo256KB_InLogRecordAttributes(string propertyKey)
        {
            // Arrange
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

            // Use LoggerMessage.Define pattern to add structured attributes
            var state = new List<KeyValuePair<string, object?>>
            {
                new(propertyKey, s_largePayload),
            };
            logger.Log(LogLevel.Information, 0, state, null, (s, e) => "test message");

            Assert.Single(logRecords);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out _, out _, out _, out _);

            // Assert
            Assert.True(properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in the properties dictionary.");
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }

        [Fact]
        public void NonGenAiProperties_AreTruncated_InLogRecordAttributes()
        {
            // Arrange
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
                new("regular.property", s_largePayload),
            };
            logger.Log(LogLevel.Information, 0, state, null, (s, e) => "test message");

            Assert.Single(logRecords);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out _, out _, out _, out _);

            // Assert
            Assert.True(properties.TryGetValue("regular.property", out var value));
            Assert.Equal(SchemaConstants.MessageData_Properties_MaxValueLength, value!.Length);
        }

        [Theory]
        [InlineData("gen_ai.input.messages")]
        [InlineData("gen_ai.output.messages")]
        [InlineData("gen_ai.system_instructions")]
        [InlineData("gen_ai.tool.definitions")]
        [InlineData("gen_ai.tool.call.arguments")]
        [InlineData("gen_ai.tool.call.result")]
        [InlineData("gen_ai.evaluation.explanation")]
        public void GenAiProperties_AreTruncatedTo256KB_InActivityCustomDimensions(string propertyKey)
        {
            // Arrange
            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            using var activity = activitySource.StartActivity(
                "TestActivity",
                ActivityKind.Client,
                parentContext: default,
                tags: new[] { new KeyValuePair<string, object?>(propertyKey, s_largePayload) });

            Assert.NotNull(activity);
            activity.Stop();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var remoteDependencyData = new RemoteDependencyData(2, activity, ref activityTagsProcessor);

            // Assert
            Assert.True(remoteDependencyData.Properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in dependency custom dimensions.");
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }

        [Theory]
        [InlineData("gen_ai.input.messages")]
        [InlineData("gen_ai.output.messages")]
        [InlineData("gen_ai.system_instructions")]
        [InlineData("gen_ai.tool.definitions")]
        [InlineData("gen_ai.tool.call.arguments")]
        [InlineData("gen_ai.tool.call.result")]
        [InlineData("gen_ai.evaluation.explanation")]
        public void GenAiProperties_AreTruncatedTo256KB_InRequestDataCustomDimensions(string propertyKey)
        {
            // Arrange
            using var activitySource = new ActivitySource(nameof(GenAiTruncationTests));
            using var activity = activitySource.StartActivity(
                "TestActivity",
                ActivityKind.Server,
                parentContext: default,
                tags: new[] { new KeyValuePair<string, object?>(propertyKey, s_largePayload) });

            Assert.NotNull(activity);
            activity.Stop();

            var activityTagsProcessor = TraceHelper.EnumerateActivityTags(activity);
            var requestData = new RequestData(2, activity, ref activityTagsProcessor);

            // Assert
            Assert.True(requestData.Properties.TryGetValue(propertyKey, out var value), $"Property '{propertyKey}' should exist in request custom dimensions.");
            Assert.Equal(SchemaConstants.GenAi_Properties_MaxValueLength, value!.Length);
        }
    }
}
