// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
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

    private sealed class ThrowingInvokeAgent : AgentApplication
    {
        public ThrowingInvokeAgent(AgentApplicationOptions options) : base(options)
        {
            OnActivity(ActivityTypes.Invoke, (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
                throw new InvalidOperationException("developer handler failure"));
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
    public void AddFoundryActivity_UsesSdkNativeConnections()
    {
        using var app = BuildApp();

        var connections = app.Services.GetRequiredService<IConnections>();
        Assert.That(connections, Is.InstanceOf<ConfigurationConnections>());
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
    public async Task MapFoundryActivity_MapsActivityMessagesPath()
    {
        using var app = BuildApp();
        await app.StartAsync();

        var client = app.GetTestClient();

        var activityResponse = await client.PostAsync("/activity/messages",
            new StringContent(
                """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a2"}""",
                System.Text.Encoding.UTF8,
                "application/json"));

        Assert.That((int)activityResponse.StatusCode, Is.EqualTo(202));

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
    public async Task MapFoundryActivity_MalformedBody_ClassifiesErrorSourceAsUser()
    {
        // CloudAdapter.ProcessAsync rejects an unparseable activity itself (400) without throwing,
        // so this exercises the OnStarting classification in ActivityEndpointHandler, not the filter.
        using var app = BuildApp();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync(
            "/activity/messages",
            new StringContent("not valid json", System.Text.Encoding.UTF8, "application/json"));

        Assert.That((int)response.StatusCode, Is.GreaterThanOrEqualTo(400));
        Assert.That(response.Headers.Contains(Core.PlatformHeaders.ErrorSource), Is.True,
            "Adapter-rejected malformed activities must still carry x-platform-error-source");
        Assert.That(response.Headers.GetValues(Core.PlatformHeaders.ErrorSource).First(), Is.EqualTo(Core.PlatformHeaders.ErrorSourceUser));

        await app.StopAsync();
    }

    [Test]
    public async Task MapFoundryActivity_InvokeHandlerThrows_ClassifiesErrorSourceAsUpstream()
    {
        // Invoke activities are synchronous request/response, so a throwing handler surfaces as a
        // 500 written directly by CloudAdapter.ProcessAsync (not queued to the background service).
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.AddAgent(sp => new ThrowingInvokeAgent(sp.GetRequiredService<AgentApplicationOptions>()));
        builder.Services.AddSingleton<IStorage, MemoryStorage>();
        builder.AddFoundryActivity();

        using var app = builder.Build();
        app.MapFoundryActivity();
        await app.StartAsync();

        var client = app.GetTestClient();
        var response = await client.PostAsync(
            "/activity/messages",
            new StringContent(
                """{"type":"invoke","name":"test","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a3"}""",
                System.Text.Encoding.UTF8,
                "application/json"));

        Assert.That((int)response.StatusCode, Is.GreaterThanOrEqualTo(500));
        Assert.That(response.Headers.Contains(Core.PlatformHeaders.ErrorSource), Is.True,
            "Adapter-surfaced processing failures must still carry x-platform-error-source");
        Assert.That(response.Headers.GetValues(Core.PlatformHeaders.ErrorSource).First(), Is.EqualTo(Core.PlatformHeaders.ErrorSourceUpstream));

        await app.StopAsync();
    }

    [Test]
    public async Task MapFoundryActivity_RawHandler_InvokesDelegateAndStampsSessionHeader()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();

        // The Activity package services are registered by AddActivityServer(); the adapter is
        // bypassed for the raw-handler request (the RequestDelegate handles it instead).
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
