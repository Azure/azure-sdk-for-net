// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class ShutdownTests
{
    [Test]
    public async Task GracefulShutdown_CompletesWithinTimeout()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddHealthChecks();
        builder.Services.Configure<HostOptions>(opts =>
        {
            opts.ShutdownTimeout = TimeSpan.FromSeconds(5);
        });

        var app = builder.Build();
        app.MapHealthEndpoint();
        await app.StartAsync();

        // Trigger graceful shutdown
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        await app.StopAsync(cts.Token);

        // If we got here without timeout, shutdown completed gracefully
        Assert.Pass("Graceful shutdown completed within timeout.");
    }
}
