// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Azure.Core.TestFramework;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using OpenTelemetry.Logs;
using OpenTelemetry;
using System.Reflection;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class E2EAzureMonitorDistroTests
    {
        internal readonly ITestOutputHelper _output;

        public E2EAzureMonitorDistroTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact(Skip="Need to investigate test failure.")]
        public async Task ValidateTelemetryExport()
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            var mockResponse = new MockResponse(200).SetContent("Ok");
            var transport = new MockTransport(mockResponse);
            builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
            {
                o.Transport = transport;
                o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            });

            var app = builder.Build();
            app.MapGet("/", () => "Hello");

            _ = app.RunAsync("http://localhost:9999");

            // Send request
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync("http://localhost:9999").ConfigureAwait(false);
            Assert.NotNull(res);

            // Wait for the backend/ingestion to receive requests
            WaitForRequest(transport);

            // Assert
            Assert.True(transport.Requests.Count > 0);

            await app.DisposeAsync();

            // Telemetry is serialized as json, and then byte encoded.
            // Need to parse the request content into something assertable.
            var data = ParseJsonRequestContent<ParsedData>(transport.Requests);
            data.ForEach(x => _output.WriteLine(x.name)); // Output to console to investigate test failures.
            Assert.Equal(15, data.Count); // Total telemetry items

            // Group all parsed telemetry by name and get the count per name.
            var summary = data.GroupBy(x => x.name).ToDictionary(x => x.Key!, x => x.Count());

            Assert.Equal(4, summary.Count); // Total unique telemetry items
            Assert.Equal(8, summary["Message"]); // Count of telemetry items
            Assert.Equal(5, summary["Metric"]);
            Assert.Equal(1, summary["RemoteDependency"]);
            Assert.Equal(1, summary["Request"]);

            // TODO: This test needs to assert telemetry content. (ie: sample rate)
        }

        [Theory]
        [InlineData(null)]
        [InlineData("true")]
        [InlineData("True")]
        [InlineData("False")]
        [InlineData("false")]
        public void ValidateLogFilteringProcessorIsAddedToLoggerProvider(string enableLogSampling)
        {
            try
            {
                Environment.SetEnvironmentVariable("OTEL_DOTNET_AZURE_MONITOR_EXPERIMENTAL_ENABLE_LOG_SAMPLING", enableLogSampling);

                var sv = new ServiceCollection();
                sv.AddOpenTelemetry().UseAzureMonitor(o => o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000");

                var sp = sv.BuildServiceProvider();
                var loggerProvider = sp.GetRequiredService<ILoggerProvider>();
                var sdkProvider = typeof(OpenTelemetryLoggerProvider).GetField("Provider", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(loggerProvider);
                var processor = sdkProvider?.GetType().GetProperty("Processor", BindingFlags.Instance | BindingFlags.Public)?.GetMethod?.Invoke(sdkProvider, null);

                Assert.NotNull(processor);

                if (enableLogSampling != null && enableLogSampling.Equals("true" , StringComparison.OrdinalIgnoreCase))
                {
                    Assert.True(processor is LogFilteringProcessor);
                    Assert.True(processor is BatchLogRecordExportProcessor);
                }
                else
                {
                    Assert.True(processor is not LogFilteringProcessor);
                    Assert.True(processor is BatchLogRecordExportProcessor);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable("OTEL_DOTNET_AZURE_MONITOR_EXPERIMENTAL_ENABLE_LOG_SAMPLING", null);
            }
        }

        private void WaitForRequest(MockTransport transport)
        {
            SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return transport.Requests.Count > 0;
                },
                timeout: TimeSpan.FromSeconds(10));
        }

        private static List<T> ParseJsonRequestContent<T>(List<MockRequest> requests)
        {
            var returnData = new List<T>();

            foreach (var request in requests)
            {
                var stream = new MemoryStream();
                request.Content.WriteTo(stream, CancellationToken.None);

                stream.Position = 0;
                var streamReader = new StreamReader(stream);
                var test = streamReader.ReadToEnd();

                using (StringReader stringReader = new StringReader(test))
                {
                    string? line;
                    while ((line = stringReader.ReadLine()) != null)
                    {
                        var jsonObject = JsonSerializer.Deserialize<T>(line);
                        if (jsonObject != null)
                        {
                            returnData.Add(jsonObject);
                        }
                    }
                }
            }

            return returnData;
        }

        private class ParsedData
        {
            public string? name { get; set; }
        }
    }
}
#endif
