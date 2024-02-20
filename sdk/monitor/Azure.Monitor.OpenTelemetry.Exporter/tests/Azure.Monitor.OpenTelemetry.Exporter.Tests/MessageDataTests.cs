// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Microsoft.Extensions.Logging;

using OpenTelemetry.Logs;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MessageDataTests
    {
        [Theory]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Critical)]
        [InlineData(LogLevel.Error)]
        public void ValidateMessageData(LogLevel logLevel)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<MessageDataTests>();

            logger.Log(logLevel, "Log Message");

            var messageData = new MessageData(2, logRecords[0]);

            Assert.Equal("Log Message", messageData.Message);
            Assert.Equal(LogsHelper.GetSeverityLevel(logLevel), messageData.SeverityLevel);
            Assert.Empty(messageData.Properties);
            Assert.Empty(messageData.Measurements);
        }

        [Fact]
        public void ValidatePropertiesFromAzureMonitorResource()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<MessageDataTests>();

            logger.LogInformation("Log Message");

            var azureMonitorResource = new AzureMonitorResource();
            azureMonitorResource.UserDefinedAttributes.Add(
                new KeyValuePair<string, object>("key1", "value1"));
            azureMonitorResource.UserDefinedAttributes.Add(
                new KeyValuePair<string, object>("key2", "value2"));

            var messageData = new MessageData(2, logRecords[0], azureMonitorResource);
            Assert.Equal(2, messageData.Properties.Count);
            Assert.Equal("value1", messageData.Properties["key1"]);
            Assert.Equal("value2", messageData.Properties["key2"]);
        }

        [Fact]
        public void ValidatePropertiesFromAzureMonitorResourceWithParameterInLog()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<MessageDataTests>();

            logger.LogInformation("Log Message {Key3}", "value3");

            var azureMonitorResource = new AzureMonitorResource();
            azureMonitorResource.UserDefinedAttributes.Add(
                new KeyValuePair<string, object>("key1", "value1"));
            azureMonitorResource.UserDefinedAttributes.Add(
                new KeyValuePair<string, object>("key2", "value2"));

            var messageData = new MessageData(2, logRecords[0], azureMonitorResource);
            Assert.Equal(3, messageData.Properties.Count);
            Assert.Equal("value1", messageData.Properties["key1"]);
            Assert.Equal("value2", messageData.Properties["key2"]);
            Assert.Equal("value3", messageData.Properties["Key3"]);
        }
    }
}
