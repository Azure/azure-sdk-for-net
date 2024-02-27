// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET6_0_OR_GREATER
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOpenTelemetry().UseAzureMonitor();

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

    return $"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}";
});

#if !NETFRAMEWORK
app.MapGet("/StressTest", () =>
{
    RunStressTest();
    return "StressTest!";
});
#endif

app.Run();
#endif

#if !NETFRAMEWORK
void RunStressTest()
{
    // Get the number of available processors
    int numProcessors = Environment.ProcessorCount;

    Task[] tasks = new Task[numProcessors];

    // Start each task
    for (int i = 0; i < numProcessors; i++)
    {
        tasks[i] = Task.Run(() => Compute(cancellationTokenSource.Token));
    }

    var timeStamp = DateTime.Now.AddSeconds(20);
    while (DateTime.Now < timeStamp)
    {
        // do nothing
    }

    cancellationTokenSource.Cancel();

    Task.WaitAll(tasks);
}

void Compute(CancellationToken cancellationToken)
{
    while (!cancellationToken.IsCancellationRequested)
    {
        // Simulate intensive computation
        double result = 0;
        for (int i = 0; i < 1000000; i++)
        {
            result += Math.Sqrt(i);
        }
    }
}
#endif
