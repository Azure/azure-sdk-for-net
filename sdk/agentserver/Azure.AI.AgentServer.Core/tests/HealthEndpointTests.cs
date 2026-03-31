// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests;

[TestFixture]
public class HealthEndpointTests
{
    [Test]
    public async Task HealthEndpoint_Returns200()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddHealthChecks();

        var app = builder.Build();
        app.MapHealthEndpoint();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/readiness");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        await app.StopAsync();
    }
}
