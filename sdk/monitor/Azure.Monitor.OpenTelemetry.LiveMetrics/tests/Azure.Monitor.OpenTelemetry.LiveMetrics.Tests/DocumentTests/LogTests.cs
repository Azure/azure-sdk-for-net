// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class LogTests : DocumentTestBase
    {
        public LogTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void VerifyLogRecord(bool formatMessage)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<LogRecord> telemetryItems = new();

            var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = formatMessage;
                    options.AddInMemoryExporter(telemetryItems);
                }));

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.Log(
                logLevel: LogLevel.Information,
                eventId: 0,
                exception: null,
                message: "Hello {name}.",
                args: new object[] { "World" });

            // CLEANUP
            loggerFactory.Dispose();

            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var logDocument = DocumentHelper.ConvertToLogDocument(telemetryItems.First());

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Trace, logDocument.DocumentType);

            if (formatMessage)
            {
                Assert.Equal("Hello World.", logDocument.Message);
            }
            else
            {
                Assert.Equal("Hello {name}.", logDocument.Message);
            }

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, logDocument.Extension_Duration);
            Assert.False(logDocument.Extension_IsSuccess);
        }

        [Fact]
        public void VerifyLogRecordWithException()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<LogRecord> telemetryItems = new();

            var loggerFactory = LoggerFactory.Create(builder =>
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(telemetryItems);
                }));

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            try
            {
                throw new System.Exception("Test exception");
            }
            catch (System.Exception ex)
            {
                logger.Log(
                    logLevel: LogLevel.Error,
                    eventId: 0,
                    exception: ex,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            loggerFactory.Dispose();

            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var logRecord = telemetryItems.First();
            Assert.NotNull(logRecord.Exception);

            var exceptionDocument = DocumentHelper.ConvertToExceptionDocument(logRecord.Exception);

            // ASSERT
            Assert.Equal(DocumentIngressDocumentType.Exception, exceptionDocument.DocumentType);
            Assert.Equal(typeof(System.Exception).FullName, exceptionDocument.ExceptionType);
            Assert.Equal("Test exception", exceptionDocument.ExceptionMessage);

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, exceptionDocument.Extension_Duration);
            Assert.False(exceptionDocument.Extension_IsSuccess);
        }
    }
}
