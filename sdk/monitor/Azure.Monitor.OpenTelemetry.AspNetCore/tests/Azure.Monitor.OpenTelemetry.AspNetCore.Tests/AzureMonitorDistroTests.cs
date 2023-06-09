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

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class AzureMonitorDistroTests
    {
        [Fact]
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

            var data = ParseContent<ParsedData>(transport.Requests);
            Assert.Equal(15, data.Count);

            var summary = data.GroupBy(x => x.name).Select(x => new SummaryData { Name = x.Key, Count = x.Count() }).OrderBy(x => x.Name).ToList();
            Assert.Equivalent(new SummaryData { Name = "Message", Count = 8 }, summary[0]);
            Assert.Equivalent(new SummaryData { Name = "Metric", Count = 5 }, summary[1]);
            Assert.Equivalent(new SummaryData { Name = "RemoteDependency", Count = 1 }, summary[2]);
            Assert.Equivalent(new SummaryData { Name = "Request", Count = 1 }, summary[3]);
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

        private static List<T> ParseContent<T>(List<MockRequest> requests)
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

        private class SummaryData
        {
            public string? Name { get; set; }
            public int? Count { get; set; }
        }
    }
}
#endif
