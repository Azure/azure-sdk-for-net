// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.PerformanceCounters
{
    public class PerformanceCounterCollectorFactoryTests
    {
        [Theory]
        [InlineData(true, true, nameof(AzureWebAppWindowsPerformanceCounterCollector))]
        [InlineData(true, false, nameof(WindowsPerformanceCounterCollector))]
        [InlineData(false, true, nameof(NonWindowsPerformanceCounterCollector))]
        [InlineData(false, false, nameof(NonWindowsPerformanceCounterCollector))]
        public void VerifyFactoryDecision(bool isWindows, bool isAzureAppService, string expectedTypeName)
        {
            var platform = new MockPlatform
            {
                IsOsPlatformFunc = (os) => os.ToString() == (isWindows ? "WINDOWS" : "LINUX")
            };

            PerformanceCounterCollectorFactory.TryGetInstance(platform, isAzureAppService, out var perfCounterCollector);

            Assert.Equal(expectedTypeName, perfCounterCollector!.GetType().Name);
        }
    }
}
