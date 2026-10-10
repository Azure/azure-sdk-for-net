// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text.Json;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.CustomerSdkStats;

public class CustomerSdkStatsHelperTests
{
    [Fact]
    public void TrackDropped_SeparatesRequestAndDependencyCountsByTelemetrySuccess()
    {
        var measurements = new List<(long Count, string TelemetryType, string? TelemetrySuccess)>();
        using var listener = new MeterListener
        {
            InstrumentPublished = (instrument, meterListener) =>
            {
                if (instrument.Meter.Name == CustomerSdkStatsMeters.MeterName
                    && instrument.Name == "Item_Dropped_Count")
                {
                    meterListener.EnableMeasurementEvents(instrument);
                }
            },
        };
        listener.SetMeasurementEventCallback<long>((_, count, tags, _) =>
        {
            string? telemetryType = null;
            string? telemetrySuccess = null;
            string? dropCode = null;

            foreach (var tag in tags)
            {
                if (tag.Key == "telemetryType")
                {
                    telemetryType = tag.Value as string;
                }
                else if (tag.Key == "telemetrySuccess")
                {
                    telemetrySuccess = tag.Value as string;
                }
                else if (tag.Key == "dropCode")
                {
                    dropCode = tag.Value as string;
                }
            }

            if (dropCode == "402" && telemetryType != null)
            {
                measurements.Add((count, telemetryType, telemetrySuccess));
            }
        });
        listener.Start();

        var counter = new TelemetrySchemaTypeCounter();
        counter.IncrementRequest(success: true);
        counter.IncrementRequest(success: true);
        counter.IncrementRequest(success: false);
        counter.IncrementDependency(success: false);
        counter.IncrementDependency(success: null);

        CustomerSdkStatsHelper.TrackDropped(counter, 402, "Daily quota exceeded");

        Assert.Contains((2, "REQUEST", "true"), measurements);
        Assert.Contains((1, "REQUEST", "false"), measurements);
        Assert.Contains((1, "DEPENDENCY", "false"), measurements);
        Assert.Contains((1, "DEPENDENCY", null), measurements);
    }

    [Theory]
    [InlineData("Request", true)]
    [InlineData("Request", false)]
    [InlineData("RemoteDependency", true)]
    [InlineData("RemoteDependency", false)]
    public void GetTelemetryDetailsFromJson_ReadsRequestAndDependencySuccess(string telemetryType, bool telemetrySuccess)
    {
        var json = JsonSerializer.Serialize(new
        {
            name = telemetryType,
            data = new
            {
                baseData = new
                {
                    success = telemetrySuccess,
                },
            },
        });

        var details = HttpPipelineHelper.GetTelemetryDetailsFromJson(json);

        Assert.Equal(telemetryType, details.TelemetryType);
        Assert.Equal(telemetrySuccess, details.TelemetrySuccess);
    }
}
