// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.Metrics;
using System.Text;
using System.Threading;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MetricExporterTests
    {
        [Fact]
        public void Test1()
        {
            Meter MyMeter = new Meter("MyCompany.MyProduct.MyLibrary", "1.0");
            Counter<double> MyFruitCounter = MyMeter.CreateCounter<double>("MySyncCounter");

            using var meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("MyCompany.MyProduct.MyLibrary")
            .AzureMonitorMetricExporter(o => {
                o.ConnectionString = "InstrumentationKey=ebff0d7e-7643-4a6d-9597-a17fdea8e8bf;IngestionEndpoint=https://westus2-0.in.applicationinsights.azure.com/";
            })
            .Build();

            MyFruitCounter.Add(1, new("type", "fruit"), new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(1, new("type", "fruit"), new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(1, new("type", "fruit"), new("name", "apple"), new("color", "green"));
            MyFruitCounter.Add(1, new("type", "vehicle"), new("name", "honda"), new("color", "red"));

            Thread.Sleep(90000);
        }
    }
}
