// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on availability telemetry logging.
    /// </summary>
    public class AvailabilityTests
    {
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        internal readonly Dictionary<string, object> testResourceAttributes = new()
        {
            { "service.instance.id", "testInstance" },
            { "service.name", "testName" },
            { "service.namespace", "testNamespace" },
            { "service.version", "testVersion" },
        };

        public AvailabilityTests(ITestOutputHelper output)
        {
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Fact]
        public void VerifyAvailabilityTelemetryViaLogMethod()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, LogLevel.Information)
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("{microsoft.availability.id} {microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success} {microsoft.availability.runLocation} {microsoft.availability.message}",
                "test-id-123", "MyAvailabilityTest", "00:00:05", true, "West US", "Test completed successfully");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Availability").Single();

            TelemetryItemValidationHelper.AssertAvailabilityTelemetry(
                telemetryItem: telemetryItem!,
                expectedId: "test-id-123",
                expectedName: "MyAvailabilityTest",
                expectedDuration: "00:00:05",
                expectedSuccess: true,
                expectedRunLocation: "West US",
                expectedMessage: "Test completed successfully",
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Fact]
        public void VerifyAvailabilityTelemetryWithMinimalFields()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, LogLevel.Information)
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("{microsoft.availability.id} {microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success}",
                "test-id-456", "MinimalTest", "00:00:02", false);

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Availability").Single();

            TelemetryItemValidationHelper.AssertAvailabilityTelemetry(
                telemetryItem: telemetryItem!,
                expectedId: "test-id-456",
                expectedName: "MinimalTest",
                expectedDuration: "00:00:02",
                expectedSuccess: false,
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Fact]
        public void VerifyAvailabilityWithClientIP()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();
            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("{microsoft.availability.id} {microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success} {microsoft.client.ip}",
                "test-id-789", "TestWithIP", "00:00:03", true, "1.2.3.4");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Availability").Single();

            TelemetryItemValidationHelper.AssertAvailabilityTelemetry(
                telemetryItem: telemetryItem!,
                expectedId: "test-id-789",
                expectedName: "TestWithIP",
                expectedDuration: "00:00:03",
                expectedSuccess: true,
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null,
                expectedClientIp: "1.2.3.4");
        }

        [Fact]
        public void VerifyExceptionTakesPrecedence()
        {
            // This test confirms that if a LogRecord contains both an exception and the "availability" attributes then only an exception will be exported.

            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, LogLevel.Information)
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                logger.Log(
                    logLevel: LogLevel.Information,
                    eventId: 1,
                    exception: ex,
                    message: "{microsoft.availability.id} {microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success}",
                    args: new object[] { "test-id", "TestName", "00:00:01", true });
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems!.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            Assert.Single(telemetryItems!.Where(x => x.Name == "Exception"));
            Assert.DoesNotContain(telemetryItems!, x => x.Name == "Availability");
        }

        [Fact]
        public void VerifyAvailabilityWithAdditionalProperties()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, LogLevel.Information)
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("{microsoft.availability.id} {microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success} {customProp1} {customProp2}",
                "test-id-999", "TestWithProps", "00:00:04", true, "value1", "value2");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Availability").Single();

            var availabilityData = (AvailabilityData)telemetryItem!.Data.BaseData;
            Assert.Equal("test-id-999", availabilityData.Id);
            Assert.Equal("TestWithProps", availabilityData.Name);
            Assert.Equal("00:00:04", availabilityData.Duration);
            Assert.True(availabilityData.Success);

            // Verify custom properties are included
            Assert.True(availabilityData.Properties.ContainsKey("customProp1"));
            Assert.Equal("value1", availabilityData.Properties["customProp1"]);
            Assert.True(availabilityData.Properties.ContainsKey("customProp2"));
            Assert.Equal("value2", availabilityData.Properties["customProp2"]);
        }

        [Fact]
        public void VerifyIncompleteAvailabilityDataFallsBackToMessage()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();
            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, LogLevel.Information)
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT - Log with only 3 of the 4 required fields (missing 'id')
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("{microsoft.availability.name} {microsoft.availability.duration} {microsoft.availability.success}",
                "TestName", "00:00:01", true);

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            // Should be Message telemetry, not Availability
            Assert.DoesNotContain(telemetryItems!, x => x.Name == "Availability");
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();
            Assert.NotNull(telemetryItem);
        }
    }
}
