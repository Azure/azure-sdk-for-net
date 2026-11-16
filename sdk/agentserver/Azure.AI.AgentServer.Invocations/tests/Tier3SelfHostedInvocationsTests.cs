// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    [TestCase(false)]
    [TestCase(true)]
    public async Task SelfHosted_AuthorizationSample_ProtectsHttpAndWebSocket(bool authenticated)
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        Sample7Snippets.ConfigureAuthenticatedServices(builder);
        builder.Services.AddScoped<InvocationHandler, SampleWs1Snippets.EchoAgentHandler>();
        await using var app = builder.Build();
        Sample7Snippets.MapAuthenticatedInvocations(app);
        app.MapGet("/test-sign-in", async (HttpContext context) =>
        {
            var principal = new ClaimsPrincipal(new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.NameIdentifier, "test-user") },
                CookieAuthenticationDefaults.AuthenticationScheme));
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        });
        await app.StartAsync();
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        using var client = app.GetTestClient();
        string? cookie = null;
        if (authenticated)
        {
            using var signIn = await client.GetAsync("/test-sign-in", timeout.Token);
            cookie = signIn.Headers.GetValues("Set-Cookie").Single().Split(';')[0];
            client.DefaultRequestHeaders.Add("Cookie", cookie);
        }

        using var response = await client.PostAsync("/invocations", new StringContent("hello"), timeout.Token);
        Assert.That(response.StatusCode, Is.EqualTo(authenticated ? HttpStatusCode.OK : HttpStatusCode.Unauthorized));
        var server = app.GetTestServer();
        var wsClient = server.CreateWebSocketClient();
        wsClient.ConfigureRequest = request =>
        {
            request.Headers.Origin = "https://client.example";
            if (cookie is not null)
            {
                request.Headers.Cookie = cookie;
            }
        };
        var uri = new Uri(server.BaseAddress, "invocations_ws");
        if (authenticated)
        {
            using var ws = await wsClient.ConnectAsync(uri, timeout.Token);
            var payload = Encoding.UTF8.GetBytes("authenticated");
            await ws.SendAsync(payload, WebSocketMessageType.Text, true, timeout.Token);
            var buffer = new byte[256];
            var received = await ws.ReceiveAsync(buffer, timeout.Token);
            Assert.That(Encoding.UTF8.GetString(buffer, 0, received.Count), Is.EqualTo("authenticated"));
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "done", timeout.Token);
        }
        else
        {
            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await wsClient.ConnectAsync(uri, timeout.Token));
            Assert.That(ex!.Message, Does.Contain("401"));
        }
    }

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
