// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.DocumentTests
{
    public abstract class DocumentTestBase
    {
        public readonly ITestOutputHelper testOutput;

        public DocumentTestBase(ITestOutputHelper output)
        {
            testOutput = output;
        }

        /// <summary>
        /// Wait for End callback to execute because it is executed after response was returned.
        /// </summary>
        /// <remarks>
        /// Copied from <see href="https://github.com/open-telemetry/opentelemetry-dotnet/blob/f471a9f197d797015123fe95d3e12b6abf8e1f5f/test/OpenTelemetry.Instrumentation.AspNetCore.Tests/BasicTests.cs#L558-L570"/>.
        /// </remarks>
        internal static void WaitForActivityExport(List<Activity> telemetryItems)
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return telemetryItems.Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            if (!result)
            {
                Assert.Fail("WaitForActivityExport failed. Test project did not capture telemetry.");
            }
        }

        internal void PrintActivity(Activity activity)
        {
            testOutput.WriteLine($"DisplayName: {activity.DisplayName}");
            testOutput.WriteLine($"Kind: {activity.Kind}");
            testOutput.WriteLine($"Status: {activity.Status}");
            testOutput.WriteLine("Tags:");
            foreach (ref readonly var tag in activity.EnumerateTagObjects())
            {
                testOutput.WriteLine($"\t{tag.Key}:{tag.Value}");
            }
        }
    }
}
