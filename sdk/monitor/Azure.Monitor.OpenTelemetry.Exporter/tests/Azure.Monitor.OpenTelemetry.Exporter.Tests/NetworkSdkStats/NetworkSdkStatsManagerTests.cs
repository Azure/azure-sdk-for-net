// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.NetworkSdkStats
{
    public class NetworkSdkStatsManagerTests
    {
        [Theory]
        [InlineData("westus-0.in.applicationinsights.azure.com", "westus-0")]
        [InlineData("westus2-1.in.applicationinsights.azure.com", "westus2-1")]
        [InlineData("eastus", "eastus")]
        [InlineData("www.westeurope-5.in.applicationinsights.azure.com", "westeurope-5")]
        [InlineData("", "unknown")]
        [InlineData(null, "unknown")]
        public void ExtractStampHost_ReturnsStampSpecificRegion(string? input, string expected)
        {
            Assert.Equal(expected, NetworkSdkStatsHelper.ExtractStampHost(input));
        }

        [Fact]
        public void BuildBaseTags_IncludesAllRequiredDimensions()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000001;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");

            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            var tags = manager.BuildBaseTags("westus-0");

            // All dimensions required by the Network SDKStats spec for Request_Success_Count.
            Assert.Contains(tags, t => t.Key == "rp");
            Assert.Contains(tags, t => t.Key == "attach");
            Assert.Contains(tags, t => t.Key == "cikey" && (string?)t.Value == "00000000-0000-0000-0000-000000000001");
            Assert.Contains(tags, t => t.Key == "runtimeVersion");
            Assert.Contains(tags, t => t.Key == "os");
            Assert.Contains(tags, t => t.Key == "language" && (string?)t.Value == "dotnet");
            Assert.Contains(tags, t => t.Key == "version");
            Assert.Contains(tags, t => t.Key == "endpoint" && (string?)t.Value == StatsbeatConstants.NetworkSdkStatsEndpointBreeze);
            Assert.Contains(tags, t => t.Key == "host" && (string?)t.Value == "westus-0");
        }

        [Fact]
        public void TrackSuccess_RecordsRequestSuccessCount()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000002;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            string? observedHost = null;

            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, tags, _) =>
            {
                recorded += value;
                foreach (var t in tags)
                {
                    if (t.Key == "host")
                    {
                        observedHost = t.Value as string;
                    }
                }
            });
            listener.Start();

            manager.TrackSuccess("westus-0.in.applicationinsights.azure.com");

            Assert.Equal(1, recorded);
            Assert.Equal("westus-0", observedHost);
        }

        [Fact]
        public void TrackPartialSuccessAccepted_RecordsRequestSuccessCountWithAcceptedCount()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000003;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, _, _) => recorded += value);
            listener.Start();

            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", 7);

            Assert.Equal(7, recorded);
        }

        [Fact]
        public void TrackPartialSuccessAccepted_ZeroOrNegativeCount_DoesNotRecord()
        {
            var connectionVars = ConnectionStringParser.GetValues(
                "InstrumentationKey=00000000-0000-0000-0000-000000000004;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/");
            var manager = new NetworkSdkStatsManager(connectionVars, new MockPlatform());

            long recorded = 0;
            using var listener = new MeterListener
            {
                InstrumentPublished = (instrument, l) =>
                {
                    if (instrument.Meter.Name == StatsbeatConstants.NetworkSdkStatsMeterName
                        && instrument.Name == "Request_Success_Count")
                    {
                        l.EnableMeasurementEvents(instrument);
                    }
                },
            };
            listener.SetMeasurementEventCallback<long>((_, value, _, _) => recorded += value);
            listener.Start();

            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", 0);
            manager.TrackPartialSuccessAccepted("westus-0.in.applicationinsights.azure.com", -3);

            Assert.Equal(0, recorded);
        }
    }
}
