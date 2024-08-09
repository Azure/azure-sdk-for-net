// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System.Diagnostics;
using System.Net.Http;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Instrumentation.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenTelemetry().UseAzureMonitor();

builder.Services.Configure<HttpClientTraceInstrumentationOptions>(options =>
{
    options.RecordException = true;
    options.FilterHttpRequestMessage = (httpRequestMessage) =>
    {
        // only collect telemetry about HTTP GET requests
        //return true;

        if (httpRequestMessage.RequestUri?.Host.Equals("www.bing.com") ?? false)
        {
            return false;
        }

        return true;
    };
});

/*
builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-00000000CODE";
    // Set the Credential property to enable AAD based authentication:
    // o.Credential = new DefaultAzureCredential();
});
*/

var app = builder.Build();
app.MapGet("/", () =>
{
    app.Logger.LogInformation("Hello World!");

    using var client = new HttpClient();
    var response = client.GetAsync("https://www.bing.com/").Result;
    var response2 = client.GetAsync("https://www.google.com/").Result;

    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});

app.Run();
#endif
