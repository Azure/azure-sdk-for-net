// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// Verifies the Microsoft 365 Agents SDK-native hosting path: an existing agent registered with
/// <c>builder.AddAgent&lt;TAgent&gt;()</c> is exposed over the Foundry Activity protocol by
/// <see cref="FoundryActivityHostingExtensions.AddFoundryActivity(IHostApplicationBuilder, System.Action{ActivityServerOptions})"/>
/// and <see cref="FoundryActivityEndpointRouteBuilderExtensions.MapFoundryActivity(WebApplication)"/>.
/// </summary>
[TestFixture]
public class FoundryActivityHostingTests
{
    private sealed class EchoAgent : AgentApplication
    {
        public EchoAgent(AgentApplicationOptions options) : base(options)
        {
            OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            });
        }
    }

    private static WebApplication BuildApp()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();

        // The exact Microsoft 365 Agents SDK registration an existing sample already has.
        builder.AddAgent<EchoAgent>();
        builder.Services.AddSingleton<IStorage, MemoryStorage>();

        // The Foundry conversion: one added line.
        builder.AddFoundryActivity();

        var app = builder.Build();
        app.MapFoundryActivity();
        return app;
    }

    [Test]
    public void AddFoundryActivity_SubstitutesFoundryConnections()
    {
        using var app = BuildApp();

        var connections = app.Services.GetRequiredService<IConnections>();
        Assert.That(connections, Is.InstanceOf<FoundryConnections>());
    }

    [Test]
    public void AddFoundryActivity_RegistersAdapterAndEndpointHandler()
    {
        using var app = BuildApp();

        Assert.Multiple(() =>
        {
            Assert.That(app.Services.GetService<IAgentHttpAdapter>(), Is.Not.Null);
            Assert.That(app.Services.GetService<ActivityEndpointHandler>(), Is.Not.Null);
            Assert.That(app.Services.GetService<IAgent>(), Is.InstanceOf<EchoAgent>());
        });
    }

    [Test]
    public async Task MapFoundryActivity_ReturnsAccepted_ForNormalMessage()
    {
        using var app = BuildApp();
        await app.StartAsync();

        var client = app.GetTestClient();
        var activity = new StringContent(
            """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a1"}""",
            System.Text.Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync("/activity/messages", activity);

        // Normal-delivery messages are queued to the background service and acknowledged with 202.
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(response.Headers.Contains(Core.PlatformHeaders.SessionId), Is.True);

        await app.StopAsync();
    }

    [Test]
    public async Task MapFoundryActivity_MapsActivityMessagesPath_AndNotApiMessages()
    {
        using var app = BuildApp();
        await app.StartAsync();

        var client = app.GetTestClient();

        var activityResponse = await client.PostAsync("/activity/messages",
            new StringContent(
                """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a2"}""",
                System.Text.Encoding.UTF8,
                "application/json"));

        // The Bot Framework-compatible /api/messages path is intentionally not mapped.
        var apiResponse = await client.PostAsync("/api/messages",
            new StringContent(
                """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a1"}""",
                System.Text.Encoding.UTF8,
                "application/json"));

        Assert.Multiple(() =>
        {
            Assert.That((int)activityResponse.StatusCode, Is.EqualTo(202));
            Assert.That((int)apiResponse.StatusCode, Is.EqualTo(404));
        });

        await app.StopAsync();
    }

    [Test]
    public async Task MapFoundryActivity_ExposesReadinessProbe()
    {
        using var app = BuildApp();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.GetAsync("/readiness");

        Assert.That((int)response.StatusCode, Is.EqualTo(200));

        await app.StopAsync();
    }

    [Test]
    public async Task MapFoundryActivity_RawHandler_InvokesDelegateAndStampsSessionHeader()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();

        // Only the Activity package services are needed for the session/baggage stamping; the
        // Microsoft 365 Agents SDK stack is not initialized on the raw-handler path.
        builder.Services.AddActivityServer();

        using var app = builder.Build();
        app.UseAgentServerCore();

        // Own the request pipeline: read the request and write the response yourself.
        ((Microsoft.AspNetCore.Routing.IEndpointRouteBuilder)app).MapFoundryActivity(async context =>
        {
            using var reader = new System.IO.StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync($"handled:{body.Length}");
        });

        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync("/activity/messages",
            new StringContent("{\"type\":\"message\",\"text\":\"hi\"}", System.Text.Encoding.UTF8, "application/json"));

        Assert.Multiple(() =>
        {
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.That(response.Headers.Contains(Core.PlatformHeaders.SessionId), Is.True);
        });

        var text = await response.Content.ReadAsStringAsync();
        Assert.That(text, Does.StartWith("handled:"));

        await app.StopAsync();
    }

    [Test]
    public void MapFoundryActivity_RawHandler_NullHandler_Throws()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddActivityServer();
        using var app = builder.Build();

        Assert.Throws<ArgumentNullException>(
            () => ((Microsoft.AspNetCore.Routing.IEndpointRouteBuilder)app).MapFoundryActivity((Microsoft.AspNetCore.Http.RequestDelegate)null!));
    }
}
