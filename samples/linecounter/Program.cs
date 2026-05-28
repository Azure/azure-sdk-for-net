// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.AspNetCore;
using LineCounter;
using Microsoft.Extensions.Azure;

// Messaging libraries still require feature flag.
AppContext.SetSwitch("Azure.Experimental.EnableActivitySource", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAzureClients(
    c => {
        c.ConfigureDefaults(builder.Configuration.GetSection("Defaults"));

        c.AddBlobServiceClient(builder.Configuration.GetSection("Blob"));
        c.AddEventHubProducerClient(builder.Configuration.GetSection("Uploads")).WithName("Uploads");

        c.AddEventHubProducerClient(builder.Configuration.GetSection("Results")).WithName("Results");
        c.AddEventGridPublisherClient(builder.Configuration.GetSection("Notification"));
    });

builder.Services.AddSingleton<IHostedService, LineCounterService>();
builder.Services.AddOpenTelemetry().UseAzureMonitor();


var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
