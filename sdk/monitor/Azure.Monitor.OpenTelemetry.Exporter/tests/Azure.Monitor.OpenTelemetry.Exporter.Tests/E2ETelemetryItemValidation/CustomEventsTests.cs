// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="LoggerFactory"/> and <see cref="Logger"/>.
    /// </summary>
    public class CustomEventsTests
    {
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        internal readonly Dictionary<string, object> testResourceAttributes = new()
        {
            { "service.instance.id", "testInstance" },
            { "service.name", "testName" },
            { "service.namespace", "testNamespace" },
            { "service.version", "testVersion" },
        };

        public CustomEventsTests(ITestOutputHelper output)
        {
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Fact]
        public void VerifyExceptionTakesPrecence()
        {
            // This test confirms that if a LogRecord contains both an exception and the "customevent" attribute then only an exception will be exported.

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
                    message: "Hello {name} {microsoft.custom_event.name}.",
                    args: new object[] { "World", "MyCustomEventName" });
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems!.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            Assert.Single(telemetryItems!.Where(x => x.Name == "Exception"));
            Assert.DoesNotContain(telemetryItems!, x => x.Name == "Event");
        }

        [Fact]
        public void VerifyCustomEventViaLogMethod()
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
            logger.LogInformation("{microsoft.custom_event.name}", "MyCustomEventName");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "MyCustomEventName",
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Fact]
        public void VerifyCustomEventWithClientIP()
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
            logger.LogInformation("{microsoft.custom_event.name} {microsoft.client.ip}", "MyCustomEventName", "1.2.3.4");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "MyCustomEventName",
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null,
                expectedClientIp: "1.2.3.4");
        }

        [Fact]
        public void VerifyCustomEventNotExporterViaScopes()
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
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            List<KeyValuePair<string, object>> scope1 = new()
            {
                new("scopeKey1", "scopeValue1"),
                new("scopeKey2", "scopeValue2")
            };

            List<KeyValuePair<string, object>> scope2 = new()
            {
                new("microsoft.custom_event.name", "MyCustomEventName")
            };

            using (logger.BeginScope(scope1))
            using (logger.BeginScope(scope2))
            {
                logger.Log(
                    logLevel: LogLevel.Information,
                    eventId: 1,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            Assert.Single(telemetryItems!.Where(x => x.Name == "Message"));
            Assert.DoesNotContain(telemetryItems!, x => x.Name == "Event");

            var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();
            var messageData = (MessageData)telemetryItem!.Data.BaseData;

            Assert.True(messageData.Properties.ContainsKey("microsoft.custom_event.name"));
        }

        [Fact]
        public void VerifyCustomEventViaSourceGenerated()
        {
            // This method is testing Compile-time logging source generation.
            // https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator

            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            logger.WriteSimpleCustomEvent("MyCustomEventName");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "MyCustomEventName",
                expectedProperties: new Dictionary<string, string> (),
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Fact]
        public void VerifyCustomEventWithClientAddressSourceGenerated()
        {
            // This method is testing Compile-time logging source generation for custom event with client.address.
            // https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator

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
            logger.WriteCustomEventWithClientAddress("MyCustomEventName", "1.2.3.4");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "MyCustomEventName",
                expectedProperties: new Dictionary<string, string>(),
                expectedSpanId: null,
                expectedTraceId: null,
                expectedClientIp: "1.2.3.4");
        }

        [Fact]
        public void VerifyScopeAttributeIsIgnored()
        {
            // This method is testing Compile-time logging source generation.
            // https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator

            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            List<KeyValuePair<string, object>> customEventScope = new()
            {
                new("microsoft.custom_event.name", "MyCustomEventName")
            };

            using (logger.BeginScope(customEventScope))
            {
                logger.WriteSimpleLog("value1");
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            Assert.Single(telemetryItems!.Where(x => x.Name == "Message"));
            Assert.DoesNotContain(telemetryItems!, x => x.Name == "Event");

            var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();
            var messageData = (MessageData)telemetryItem!.Data.BaseData;

            Assert.True(messageData.Properties.ContainsKey("microsoft.custom_event.name"));
        }

        [Fact]
        public void VerifyCustomEventViaSourceGeneratedWithScope()
        {
            // This method is testing Compile-time logging source generation.
            // https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator

            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            List<KeyValuePair<string, object>> scope1 = new()
            {
                new("scopeKey1", "scopeValue1"),
                new("scopeKey2", "scopeValue2")
            };

            using (logger.BeginScope(scope1))
            {
                logger.WriteCustomEventWithAdditionalProperties("MyCustomEventName", "value1", "value2");
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "MyCustomEventName",
                expectedProperties: new Dictionary<string, string> { { "key1", "value1" }, { "key2", "value2" }, { "scopeKey1", "scopeValue1" }, { "scopeKey2", "scopeValue2" } },
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Fact]
        public void VerifyCustomEventWithExtraScopeAttribute()
        {
            // This method is testing Compile-time logging source generation.
            // https://learn.microsoft.com/dotnet/core/extensions/logger-message-generator

            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            List<KeyValuePair<string, object>> customEventScope = new()
            {
                new("microsoft.custom_event.name", "Name2") // This scope attribute should be ignored and mapped as a property.
            };

            using (logger.BeginScope(customEventScope))
            {
                logger.WriteSimpleCustomEvent("Name1");
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Event").Single();

            TelemetryItemValidationHelper.AssertCustomEventTelemetry(
                telemetryItem: telemetryItem!,
                expectedName: "Name1",
                expectedProperties: new Dictionary<string, string>() { { "microsoft.custom_event.name", "Name2" } },
                expectedSpanId: null,
                expectedTraceId: null);
        }
    }
}
