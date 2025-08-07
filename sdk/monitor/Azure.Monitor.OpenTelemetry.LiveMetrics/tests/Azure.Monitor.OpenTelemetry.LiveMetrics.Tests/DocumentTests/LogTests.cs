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
                LogLevel.Information,
                0,
                null,
                "Hello {customKey1} {customKey2} {customKey3} {customKey4} {customKey5} {customKey6} {customKey7} {customKey8} {customKey9} {customKey10} {customKey11}.",
                "customValue1", "customValue2", "customValue3", "customValue4", "customValue5", "customValue6", "customValue7", "customValue8", "customValue9", "customValue10", "customValue11"
                );

            // CLEANUP
            loggerFactory.Dispose();

            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var logDocument = DocumentHelper.ConvertToLogDocument(telemetryItems.First());

            // ASSERT
            Assert.Equal(DocumentType.Trace, logDocument.DocumentType);

            if (formatMessage)
            {
                Assert.Equal("Hello customValue1 customValue2 customValue3 customValue4 customValue5 customValue6 customValue7 customValue8 customValue9 customValue10 customValue11.", logDocument.Message);
            }
            else
            {
                Assert.Equal("Hello {customKey1} {customKey2} {customKey3} {customKey4} {customKey5} {customKey6} {customKey7} {customKey8} {customKey9} {customKey10} {customKey11}.", logDocument.Message);
            }

            Assert.Equal(logCategoryName, logDocument.Properties.First(p => p.Key == "CategoryName").Value);

            VerifyCustomProperties(logDocument, 1);
            Assert.DoesNotContain(logDocument.Properties, x => x.Key == "{OriginalFormat}");

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
                    LogLevel.Information,
                    0,
                    ex,
                    "Hello {customKey1} {customKey2} {customKey3} {customKey4} {customKey5} {customKey6} {customKey7} {customKey8} {customKey9} {customKey10} {customKey11}.",
                    "customValue1", "customValue2", "customValue3", "customValue4", "customValue5", "customValue6", "customValue7", "customValue8", "customValue9", "customValue10", "customValue11"
                    );
            }

            // CLEANUP
            loggerFactory.Dispose();

            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var logRecord = telemetryItems.First();
            Assert.NotNull(logRecord.Exception);

            var exceptionDocument = DocumentHelper.ConvertToExceptionDocument(logRecord);

            // ASSERT
            Assert.Equal(DocumentType.Exception, exceptionDocument.DocumentType);
            Assert.Equal(typeof(System.Exception).FullName, exceptionDocument.ExceptionType);
            Assert.Equal("Test exception", exceptionDocument.ExceptionMessage);

            Assert.Equal(logCategoryName, exceptionDocument.Properties.First(p => p.Key == "CategoryName").Value);

            VerifyCustomProperties(exceptionDocument, 1);
            Assert.DoesNotContain(exceptionDocument.Properties, x => x.Key == "{OriginalFormat}");

            // The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            // These properties are not used for Exception and should be default values.
            Assert.Equal(default, exceptionDocument.Extension_Duration);
            Assert.False(exceptionDocument.Extension_IsSuccess);
        }
    }
}
