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
            builder.Services.AddOpenTelemetry().WithAzureMonitor(o =>
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
            // TODO: Validate request content
            Assert.True(transport.Requests.Count > 0);

            await app.DisposeAsync();
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
    }
}
#endif
