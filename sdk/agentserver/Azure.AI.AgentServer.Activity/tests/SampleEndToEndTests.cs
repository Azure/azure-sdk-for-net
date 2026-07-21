// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

/// <summary>
/// End-to-end tests that validate every shipped sample (see <c>samples/Sample*.md</c>)
/// works when wired into a real ASP.NET Core test server through the public
/// Activity pipeline (constitution Principle XIII).
///
/// <para>
/// Two tiers of assertion are used, dictated by what can be verified without a
/// live backend:
/// </para>
/// <list type="bullet">
///   <item><b>CI-safe (non-live)</b> — readiness returns 200; an inbound message
///   is accepted through the real Microsoft 365 Agents SDK pipeline and
///   acknowledged with 202 plus the platform session-id header; raw-handler
///   samples return their own response body. These run in CI.</item>
///   <item><b>Live-only</b> — actual <i>outbound reply delivery</i> requires a
///   real Bot Connector token minted by <see cref="FoundryConnections"/>, so it
///   is marked <c>[Category("Live")]</c> and excluded from CI (runnable locally
///   with user-supplied credentials and a Foundry project).</item>
/// </list>
///
/// <para>
/// The sample snippet files (<c>tests/Snippets/Sample*Snippets.cs</c>) call
/// <c>ActivityServer.Run(...)</c>, which boots a full host from the environment,
/// so they cannot be invoked directly in-process. These E2E tests therefore
/// re-declare the sample's agent/handler shape (mirroring the snippet) and drive
/// it through the same public entry points the sample uses
/// (<c>AddFoundryActivity</c> / <c>MapFoundryActivity</c>).
/// </para>
/// </summary>
[TestFixture]
public class SampleEndToEndTests
{
    private const string MessageActivityJson =
        """{"type":"message","text":"hi","from":{"id":"u1"},"recipient":{"id":"b1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a1"}""";

    private static StringContent MessageContent() =>
        new(MessageActivityJson, Encoding.UTF8, "application/json");

    /// <summary>Mirrors Sample1 (getting started) and Sample3 (digital worker): echo the message.</summary>
    private sealed class EchoAgent : AgentApplication
    {
        public EchoAgent(AgentApplicationOptions options) : base(options)
        {
            OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                var text = turnContext.Activity.Text ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    await turnContext.SendActivityAsync($"Echo: {text}", cancellationToken: cancellationToken);
                }
            });
        }
    }

    /// <summary>Mirrors Sample2 (welcome + commands): greet added members and echo messages.</summary>
    private sealed class WelcomeAgent : AgentApplication
    {
        public WelcomeAgent(AgentApplicationOptions options) : base(options)
        {
            OnConversationUpdate(ConversationUpdateEvents.MembersAdded, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync("Welcome!", cancellationToken: cancellationToken);
            });
            OnActivity(ActivityTypes.Message, async (ITurnContext turnContext, ITurnState turnState, CancellationToken cancellationToken) =>
            {
                await turnContext.SendActivityAsync($"Echo: {turnContext.Activity.Text}", cancellationToken: cancellationToken);
            });
        }
    }

    private static WebApplication BuildAgentApp<TAgent>(Action<ActivityServerOptions>? configure = null)
        where TAgent : AgentApplication
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.AddAgent<TAgent>();
        builder.Services.AddSingleton<IStorage, MemoryStorage>();
        if (configure is null)
        {
            builder.AddFoundryActivity();
        }
        else
        {
            builder.AddFoundryActivity(configure);
        }

        var app = builder.Build();
        app.MapFoundryActivity();
        return app;
    }

    [Test]
    public async Task Sample1_EchoAgent_AcceptsMessage()
    {
        using var app = BuildAgentApp<EchoAgent>();
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/activity/messages", MessageContent());

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
                Assert.That(response.Headers.Contains(Core.PlatformHeaders.SessionId), Is.True);
            });
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task Sample1_EchoAgent_ExposesReadinessProbe()
    {
        using var app = BuildAgentApp<EchoAgent>();
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.GetAsync("/readiness");
            Assert.That((int)response.StatusCode, Is.EqualTo(200));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task Sample2_WelcomeAndCommands_AcceptsMessageAndConversationUpdate()
    {
        using var app = BuildAgentApp<WelcomeAgent>();
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();

            var message = await client.PostAsync("/activity/messages", MessageContent());
            var conversationUpdate = await client.PostAsync("/activity/messages", new StringContent(
                """{"type":"conversationUpdate","membersAdded":[{"id":"u2"}],"recipient":{"id":"b1"},"from":{"id":"u1"},"conversation":{"id":"c1"},"channelId":"msteams","serviceUrl":"http://localhost:1/","id":"a2"}""",
                Encoding.UTF8,
                "application/json"));

            Assert.Multiple(() =>
            {
                Assert.That((int)message.StatusCode, Is.EqualTo(202));
                Assert.That((int)conversationUpdate.StatusCode, Is.EqualTo(202));
            });
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task Sample3_DigitalWorker_AcceptsMessage_WhenDigitalWorkerEnabled()
    {
        using var app = BuildAgentApp<EchoAgent>(options => options.DigitalWorker = true);
        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/activity/messages", MessageContent());

            Assert.Multiple(() =>
            {
                Assert.That((int)response.StatusCode, Is.EqualTo(202));
                Assert.That(response.Headers.Contains(Core.PlatformHeaders.SessionId), Is.True);
            });
        }
        finally
        {
            await app.StopAsync();
        }
    }

    [Test]
    public async Task Sample10_SelfHostRawHandler_ReturnsHandlerBody()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddActivityServer();

        using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapHealthChecks("/readiness");
        ((IEndpointRouteBuilder)app).MapFoundryActivity(async context =>
        {
            using var reader = new StreamReader(context.Request.Body);
            var body = await reader.ReadToEndAsync();
            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsync($"Received {body.Length} bytes.");
        });

        await app.StartAsync();
        try
        {
            var client = app.GetTestClient();
            var response = await client.PostAsync("/activity/messages", MessageContent());
            var text = await response.Content.ReadAsStringAsync();

            Assert.Multiple(() =>
            {
                Assert.That((int)response.StatusCode, Is.EqualTo(200));
                Assert.That(text, Does.StartWith("Received "));
                Assert.That(response.Headers.Contains(Core.PlatformHeaders.SessionId), Is.True);
            });
        }
        finally
        {
            await app.StopAsync();
        }
    }

    // Live-only E2E (excluded from CI — Principle XIII). Outbound reply delivery
    // requires a real Bot Connector token minted by FoundryConnections against a
    // live Foundry project. Runnable locally with user-supplied credentials + a
    // Foundry project via environment variables; MUST fail with a clear message
    // when that configuration is absent (never silently pass).
    [Test]
    [Category("Live")]
    public void Sample3_DigitalWorker_DeliversReply_Live()
    {
        var blueprintClientId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID");
        var tenantId = Environment.GetEnvironmentVariable("FOUNDRY_AGENT_TENANT_ID");
        var serviceUrl = Environment.GetEnvironmentVariable("ACTIVITY_TEST_SERVICE_URL");

        Assert.That(
            blueprintClientId,
            Is.Not.Null.And.Not.Empty,
            "Live reply-delivery test requires FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID. " +
            "Set the Foundry digital-worker identity environment variables and a reachable " +
            "ACTIVITY_TEST_SERVICE_URL (a Bot Connector-compatible reply sink) to run this test.");
        Assert.That(tenantId, Is.Not.Null.And.Not.Empty, "Live reply-delivery test requires FOUNDRY_AGENT_TENANT_ID.");
        Assert.That(serviceUrl, Is.Not.Null.And.Not.Empty, "Live reply-delivery test requires ACTIVITY_TEST_SERVICE_URL (reply sink).");

        // TODO(live): drive an inbound message through BuildAgentApp<EchoAgent>(o => o.DigitalWorker = true)
        // with the real serviceUrl and assert the outbound "Echo: ..." reply is delivered to the sink.
        Assert.Ignore("Live reply-delivery execution not yet implemented; configuration validation only.");
    }
}
