// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// Tier 3 self-hosted test: developer owns the host, uses Add/Map extensions.
/// No implicit health endpoint, no implicit port binding.
/// </summary>
[TestFixture]
public class Tier3SelfHostedInvocationsTests
{
    [Test]
    public async Task SelfHosted_AddAndMap_WorksWithPlainWebApplication()
    {
        // Developer creates their own WebApplication
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();

        // Developer registers Invocations services and handler
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, TestInvocationHandler>();

        var app = builder.Build();

        // Developer maps invocations routes
        app.MapInvocationsServer();

        // Developer adds their own custom route
        app.MapGet("/my-custom-route", () => Results.Ok("custom"));

        await app.StartAsync();
        var client = app.GetTestClient();

        // Protocol endpoints work
        var invocationResponse = await client.PostAsync("/invocations", new StringContent("test"));
        Assert.That(invocationResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Custom route works alongside protocol
        var customResponse = await client.GetAsync("/my-custom-route");
        Assert.That(customResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // No implicit health endpoint (developer didn't set up one)
        var healthResponse = await client.GetAsync("/readiness");
        Assert.That(healthResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        await app.StopAsync();
    }

    private sealed class TestInvocationHandler : InvocationHandler
    {
        public override async Task HandleAsync(
            HttpRequest request, HttpResponse response,
            InvocationContext context, CancellationToken cancellationToken)
        {
            response.StatusCode = 200;
            await response.WriteAsync("self-hosted-ok", cancellationToken);
        }
    }
}
