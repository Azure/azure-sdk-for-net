// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public class ManualDependencyTests : DocumentTestBase
    {
        public ManualDependencyTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(ActivityStatusCode.Ok, true)]
        [InlineData(ActivityStatusCode.Error, false)]
        [InlineData(ActivityStatusCode.Unset, true)]
        public void VerifyManualDependency(ActivityStatusCode activityStatusCode, bool expectedIsSuccess)
        {
            var exportedActivities = new List<Activity>();

            var testActivitySource = new ActivitySource("TestActivitySource");

            // SETUP
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource("TestActivitySource")
                .AddInMemoryExporter(exportedActivities)
                .Build();

            // ACT
            using (var activity = testActivitySource.StartActivity("TestActivityName", ActivityKind.Internal))
            {
                activity?.SetStatus(activityStatusCode);
            }

            tracerProvider.ForceFlush();
            WaitForActivityExport(exportedActivities);

            // Assert
            var dependencyActivity = exportedActivities.Last();
            PrintActivity(dependencyActivity);
            var dependencyDocument = DocumentHelper.ConvertToDependencyDocument(dependencyActivity);

            Assert.Null(dependencyDocument.CommandName);
            Assert.Equal(DocumentType.RemoteDependency, dependencyDocument.DocumentType);
            Assert.Equal("TestActivityName", dependencyDocument.Name);
            Assert.Equal("TestActivitySource", dependencyDocument.Properties.Single(x => x.Key == "ActivitySource").Value);

            //// The following "EXTENSION" properties are used to calculate metrics. These are not serialized.
            Assert.Equal(dependencyActivity.Duration.TotalMilliseconds, dependencyDocument.Extension_Duration);
            Assert.Equal(expectedIsSuccess, dependencyDocument.Extension_IsSuccess);
        }
    }
}
