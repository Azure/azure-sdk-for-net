// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Instrumentation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AspNetCoreInstrumentationOptions>(o =>
{
    o.EnrichWithHttpRequest = (activity, httpRequest) =>
    {
        activity.SetTag("requestProtocol", httpRequest.Protocol);
    };
    o.EnrichWithHttpResponse = (activity, httpResponse) =>
    {
        activity.SetTag("responseLength", httpResponse.ContentLength);
    };
    o.EnrichWithException = (activity, exception) =>
    {
        activity.SetTag("exceptionType", exception.GetType().ToString());
    };
});

builder.Services.AddAzureMonitorOpenTelemetry();

// This is another overload to call AddAzureMonitorOpenTelemetry with IConfiguration.
// builder.Services.AddAzureMonitorOpenTelemetry(builder.Configuration.GetSection("AzureMonitorOpenTelemetry"));

var app = builder.Build();
app.MapGet("/", () => $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}");

app.Run();
#endif
