// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Invocations.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests;

[TestFixture]
[NonParallelizable]
public class RouteOwnershipTests
{
    [TestCase(true)]
    [TestCase(false)]
    public async Task ForeignExactGetRouteFailsStartupRegardlessOfRegistrationOrder(bool foreignFirst)
    {
        await using var app = BuildApp();
        if (foreignFirst)
        {
            app.MapGet("/invocations_ws", static () => Results.Ok("foreign"));
        }

        app.MapInvocationsServer();
        if (!foreignFirst)
        {
            app.MapGet("/invocations_ws", static () => Results.Ok("foreign"));
        }

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("/invocations_ws"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task ForeignAnyMethodRouteFailsStartupRegardlessOfRegistrationOrder(bool foreignFirst)
    {
        await using var app = BuildApp();
        if (foreignFirst)
        {
            app.Map("/invocations_ws", static context => context.Response.WriteAsync("foreign"));
        }

        app.MapInvocationsServer();
        if (!foreignFirst)
        {
            app.Map("/invocations_ws", static context => context.Response.WriteAsync("foreign"));
        }

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("/invocations_ws"));
    }

    [Test]
    public async Task DuplicateInvocationsOwnerFailsStartup()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        app.MapInvocationsServer();

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("duplicate_owner"));
    }

    [Test]
    public void DirectMappingRequiresInvocationsServices()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        using var app = builder.Build();

        var exception = Assert.Throws<InvalidOperationException>(() =>
            app.MapInvocationsServer());
        Assert.That(exception!.Message, Does.Contain("AddInvocationsServer"));
    }

    [TestCase("/{tenant}")]
    [TestCase("/{*path}")]
    [TestCase("/{**path}")]
    public void NonLiteralPrefixIsRejected(string prefix)
    {
        using var app = BuildApp();

        Assert.Throws<ArgumentException>(() => app.MapInvocationsServer(prefix));
    }

    [Test]
    public async Task ForeignEquivalentCaseAndTrailingSlashRouteFailsStartup()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        app.MapGet("/INVOCATIONS_WS/", static () => Results.Ok("foreign"));

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("foreign_exact_route"));
    }

    [Test]
    public async Task PostOnlyRouteCanShareWebSocketPath()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        app.MapPost("/invocations_ws", static () => Results.Ok("post"));
        await app.StartAsync();

        var response = await app.GetTestClient().PostAsync("/invocations_ws", content: null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task DefaultOrderFallbackCanCoexistWithLiteralWebSocketRoute()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        app.MapGet("/{**path}", static () => Results.Ok("fallback"));
        await app.StartAsync();

        var response = await app.GetTestClient().GetAsync("/invocations_ws");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task DistinctLiteralPrefixesCanOwnDistinctWebSocketRoutes()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer("/v1");
        app.MapInvocationsServer("/v2/");
        await app.StartAsync();

        var endpoints = app.Services.GetRequiredService<EndpointDataSource>().Endpoints;
        var ownedRoutes = endpoints
            .OfType<RouteEndpoint>()
            .Where(endpoint => endpoint.Metadata.GetMetadata<InvocationsEndpointOwnerMetadata>() is not null)
            .Select(endpoint => endpoint.RoutePattern.RawText)
            .ToArray();

        Assert.That(ownedRoutes, Is.EquivalentTo(new[]
        {
            "/v1/invocations_ws",
            "/v2/invocations_ws",
        }));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task TypedHostRejectsForeignRouteRegardlessOfProtocolOrder(bool foreignFirst)
    {
        var builder = AgentHost.CreateBuilder();
        builder.WebApplicationBuilder.WebHost.UseTestServer();
        if (foreignFirst)
        {
            builder.RegisterProtocol("Foreign", static endpoints =>
                endpoints.MapGet("/invocations_ws", static () => Results.Ok("foreign")));
        }

        builder.AddInvocations<NoopHandler>();
        if (!foreignFirst)
        {
            builder.RegisterProtocol("Foreign", static endpoints =>
                endpoints.MapGet("/invocations_ws", static () => Results.Ok("foreign")));
        }

        var host = builder.Build();
        await using var app = host.App;

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("foreign_exact_route"));
    }

    [Test]
    public async Task OuterParameterizedGroupCannotOwnWebSocketRoute()
    {
        await using var app = BuildApp();
        app.MapGroup("/{tenant}").MapInvocationsServer();

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("non_literal_owner_route"));
    }

    [Test]
    public async Task SuppressedForeignExactRouteDoesNotConflict()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        app.MapGet("/invocations_ws", static () => Results.Ok("foreign"))
            .WithMetadata(new SuppressMatchingMetadata());

        await app.StartAsync();

        var response = await app.GetTestClient().GetAsync("/invocations_ws");
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task SuppressedOwnedWebSocketRouteFailsStartup()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer()
            .WithMetadata(new SuppressMatchingMetadata());

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("owner_suppressed"));
    }

    [Test]
    public async Task RepeatedServiceRegistrationInstallsOneOwnershipValidator()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, NoopHandler>();
        await using var app = builder.Build();
        app.MapInvocationsServer();

        var validatorCount = app.Services
            .GetServices<IStartupFilter>()
            .Count(service => service is InvocationsEndpointOwnershipValidator);

        Assert.That(validatorCount, Is.EqualTo(1));
        await app.StartAsync();
    }

    [Test]
    public async Task ServicesWithoutMappedRoutesDoNotFailStartup()
    {
        await using var app = BuildApp();

        await app.StartAsync();
    }

    [Test]
    public async Task WebSocketRouteRejectsPostWhenNoPostEndpointExists()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        await app.StartAsync();

        var response = await app.GetTestClient().PostAsync("/invocations_ws", content: null);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.MethodNotAllowed));
    }

    [Test]
    public async Task ForeignRouteFromAnotherEndpointDataSourceFailsStartup()
    {
        await using var app = BuildApp();
        app.MapInvocationsServer();
        var foreignEndpoint = new RouteEndpoint(
            static context => context.Response.WriteAsync("foreign"),
            RoutePatternFactory.Parse("/invocations_ws"),
            order: 0,
            new EndpointMetadataCollection(new HttpMethodMetadata(new[] { HttpMethods.Get })),
            "foreign endpoint data source");
        ((IEndpointRouteBuilder)app).DataSources.Add(
            new DefaultEndpointDataSource(foreignEndpoint));

        var exception = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await app.StartAsync());
        Assert.That(exception!.Message, Does.Contain("foreign endpoint data source"));
    }

    [Test]
    public async Task NestedLiteralGroupsProduceOneConcreteOwnedRoute()
    {
        await using var app = BuildApp();
        app.MapGroup("/outer").MapInvocationsServer("/inner/");
        await app.StartAsync();

        var ownedRoute = app.Services.GetRequiredService<EndpointDataSource>().Endpoints
            .OfType<RouteEndpoint>()
            .Single(endpoint =>
                endpoint.Metadata.GetMetadata<InvocationsEndpointOwnerMetadata>() is not null);

        Assert.That(ownedRoute.RoutePattern.RawText, Is.EqualTo("/outer/inner/invocations_ws"));
    }

    private static WebApplication BuildApp()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, NoopHandler>();
        return builder.Build();
    }

    private sealed class NoopHandler : InvocationHandler
    {
        public override Task HandleAsync(
            HttpRequest request,
            HttpResponse response,
            InvocationContext context,
            CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
