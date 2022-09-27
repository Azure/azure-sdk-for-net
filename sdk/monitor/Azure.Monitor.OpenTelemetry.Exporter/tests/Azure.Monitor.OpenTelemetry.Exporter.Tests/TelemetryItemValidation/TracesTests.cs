// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.TelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="TracerProvider"/> and <see cref="Activity"/>.
    /// </summary>
    public class TracesTests
    {
        private const string activitySourceName = "MyCompany.MyProduct.MyLibrary";
        private static readonly ActivitySource activitySource = new(activitySourceName);

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Internal)]
        public void VerifyTrace_CreatesDependency(ActivityKind activityKind)
        {
            // SETUP
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind ))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: telemetryItem,
                expectedName: "SayHello",
                expectedProperties: new Dictionary<string, string> { { "foo", "1" }, { "baz", "1,2,3" } });
        }

        [Theory]
        [InlineData(ActivityKind.Server)]
        [InlineData(ActivityKind.Consumer)]
        public void VerifyTrace_CreatesRequest(ActivityKind activityKind)
        {
            // SETUP
            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind))
            {
                activity?.SetTag("foo", 1);
                activity?.SetTag("baz", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertActivity_As_RequestTelemetry(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedName: "SayHello",
                expectedProperties: new Dictionary<string, string> { { "foo", "1" }, { "baz", "1,2,3" } });
        }
    }
}
