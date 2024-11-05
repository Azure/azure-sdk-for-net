// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public  class AzureMonitorExporterExtensionsTests
    {
        [Fact]
        public void AddAzureMonitorLogExporterWithNamedOptions()
        {
            var testIkey = "test_ikey";
            var testEndpoint = "https://www.bing.com/";

            string connectionString = $"InstrumentationKey={testIkey};IngestionEndpoint={testEndpoint}";

            int defaultConfigureExporterOptionsInvocations = 0;
            int namedConfigureExporterOptionsInvocations = 0;

            var sp = new ServiceCollection();
            sp.AddOpenTelemetry().WithLogging(builder => builder
                .ConfigureServices(services =>
                {
                    services.Configure<AzureMonitorExporterOptions>(o =>
                    {
                        o.ConnectionString = connectionString;
                        defaultConfigureExporterOptionsInvocations++;
                    });
                    services.Configure<AzureMonitorExporterOptions>("Exporter2", o =>
                    {
                        o.ConnectionString = connectionString;
                        namedConfigureExporterOptionsInvocations++;
                    });
                    services.Configure<AzureMonitorExporterOptions>("Exporter3", o =>
                    {
                        o.ConnectionString = connectionString;
                        namedConfigureExporterOptionsInvocations++;
                    });
                })
                .AddAzureMonitorLogExporter()
                .AddAzureMonitorLogExporter(configure: o => { }, name: "Exporter2")
                .AddAzureMonitorLogExporter(configure: o => { }, name: "Exporter3"));

            var s = sp.BuildServiceProvider();

            _ = s.GetRequiredService<LoggerProvider>();
            Assert.Equal(1, defaultConfigureExporterOptionsInvocations);
            Assert.Equal(2, namedConfigureExporterOptionsInvocations);
        }
    }
}
