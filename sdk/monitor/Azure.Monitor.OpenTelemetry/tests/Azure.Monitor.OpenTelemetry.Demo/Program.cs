// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddAzureMonitorOpenTelemetry();
builder.Services.AddAzureMonitorOpenTelemetry(o =>
{
    o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
});

var app = builder.Build();
app.MapGet("/", () =>
{
    app.Logger.LogInformation("Hello World!");
    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});

app.Run();
#endif
