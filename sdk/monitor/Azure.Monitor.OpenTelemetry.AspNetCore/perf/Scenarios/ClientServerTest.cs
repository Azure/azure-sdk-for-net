// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Test.Perf;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Perf
{
    public class ClientServerTest : PerfTest<PerfOptions>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/perf/TemplateClientTest.cs to write perf test. */

        public readonly HttpClient _httpClient;
        public readonly WebApplication _app;

        public ClientServerTest(PerfOptions options) : base(options)
        {
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            var mockResponse = new MockResponse(200).SetContent("Ok");
            var transport = new MockTransport(mockResponse);
            builder.Services.AddAzureMonitor(o =>
            {
                o.Transport = transport;
                o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                o.EnableLogs = false;
                o.EnableMetrics = false;
            });

            _app = builder.Build();
            _app.MapGet("/", () => "Hello");

            _app.RunAsync("http://localhost:9999");

            _httpClient = new HttpClient();
        }

        public override void Run(CancellationToken cancellationToken)
        {
            var res = _httpClient.GetStringAsync("http://localhost:9999").ConfigureAwait(false);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _httpClient.GetStringAsync("http://localhost:9999");
        }

        public override async Task GlobalCleanupAsync()
        {
            // Global cleanup code that runs once at the end of test execution.
            _httpClient.Dispose();
            await _app.DisposeAsync();
        }
    }
}
#endif
