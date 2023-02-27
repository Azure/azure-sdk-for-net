// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Extensions.AzureMonitor;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAzureMonitorOpenTelemetry();
builder.Services.AddAzureMonitorOpenTelemetry(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
    // To send telemetry data using AAD, set Credential property in AzureMonitorOpenTelemetryOptions.
    // For example:
    // o.Credential = new DefaultAzureCredential();
});

// To customize sampling, Set ApplicationInsightsSampler to desired sampling ratio and
// configure with OpenTelemetryTracerProvider.
// Please note that ConfigureOpenTelemetryTracerProvider should be called after
// builder.Services.AddAzureMonitorOpenTelemetry().
builder.Services.ConfigureOpenTelemetryTracerProvider((sp, builder) => builder.SetSampler(new ApplicationInsightsSampler(0.9F)));

var app = builder.Build();
app.MapGet("/", () =>
{
    app.Logger.LogInformation("Hello World!");
    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});

app.Run();
#endif
