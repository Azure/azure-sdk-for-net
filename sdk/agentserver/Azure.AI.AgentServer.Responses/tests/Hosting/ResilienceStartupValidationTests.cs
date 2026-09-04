// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Tests.Hosting;

/// <summary>
/// T006 — Fail-loud startup validation for resilient background composition.
/// When <see cref="ResponsesServerOptions.ResilientBackground"/> is enabled, the server must
/// refuse to start unless a durable (restart-surviving) <see cref="ResponsesProvider"/> is
/// composed, rather than silently downgrading to weaker durability.
/// </summary>
public sealed class ResilienceStartupValidationTests
{
    private static IHost BuildHost(Action<IServiceCollection> configureServices)
    {
        return new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer();
                webHost.ConfigureServices(services =>
                {
                    services.AddRouting();
                    configureServices(services);
                });
                webHost.Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(endpoints => endpoints.MapResponsesServer());
                });
            })
            .Build();
    }

    [Test]
    public void ResilientBackground_With_InMemory_Provider_FailsLoudly()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            using var host = BuildHost(services =>
            {
                services.AddSingleton<ResponseHandler>(new TestHandler());
                // Force the in-memory provider to win precedence, then enable resilience.
                services.AddResponsesServer(o => o.ResilientBackground = true);
                services.AddSingleton<ResponsesProvider>(sp =>
                    sp.GetRequiredService<Azure.AI.AgentServer.Responses.Internal.InMemoryResponsesProvider>());
            });
            host.Start();
        });

        XAssert.Contains("ResilientBackground", ex.Message);
        XAssert.Contains("in-memory", ex.Message);
    }

    [Test]
    public void ResilientBackground_With_FileBacked_Provider_Starts()
    {
        using var host = BuildHost(services =>
        {
            services.AddSingleton<ResponseHandler>(new TestHandler());
            services.AddResponsesServer(o => o.ResilientBackground = true);
        });

        // Default local + ResilientBackground selects the durable file-backed provider → OK.
        host.Start();
    }

    [Test]
    public void Non_Resilient_With_InMemory_Provider_Starts()
    {
        using var host = BuildHost(services =>
        {
            services.AddSingleton<ResponseHandler>(new TestHandler());
            services.AddResponsesServer(o => o.ResilientBackground = false);
        });

        // Non-resilient explicitly allows in-memory → no fail-loud.
        host.Start();
    }

    [Test]
    public void ResilientBackground_With_Custom_Durable_Provider_Starts()
    {
        using var host = BuildHost(services =>
        {
            services.AddSingleton<ResponseHandler>(new TestHandler());
            services.AddSingleton<ResponsesProvider>(new DurableStubProvider());
            services.AddResponsesServer(o => o.ResilientBackground = true);
        });

        // A consumer-supplied durable provider satisfies the resilient composition requirement.
        host.Start();
    }

    [Test]
    public void ResilientOptions_Enabled_Via_Separate_Configure_Path_ComposesTaskSubsystem()
    {
        // Issue-4 regression (CR-FINAL), now resolved by construction: the Core task subsystem
        // (ITaskInvoker) is composed for EVERY local (non-hosted) host, independent of how options are
        // set — matching Python, whose task subsystem is not option-gated. Enabling steering through a
        // configuration path OTHER than the AddResponsesServer(configure) delegate therefore can no
        // longer desync into a missing ITaskInvoker: the host starts and the task subsystem is present.
        using var host = BuildHost(services =>
        {
            services.AddSingleton<ResponseHandler>(new TestHandler());
            services.AddResponsesServer();
            // Enable steering through a separate configuration path — previously a desync source.
            services.Configure<ResponsesServerOptions>(o => o.SteerableConversations = true);
        });

        host.Start();

        // The task subsystem is composed regardless of the configuration path.
        Assert.That(host.Services.GetService<Core.Tasks.ITaskInvoker>(), Is.Not.Null);
    }

    private sealed class DurableStubProvider : ResponsesProvider
    {
        public override Task CreateResponseAsync(CreateResponseRequest request, PlatformContext context, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public override Task<Models.ResponseObject> GetResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default) => throw new ResourceNotFoundException(responseId);
        public override Task UpdateResponseAsync(Models.ResponseObject response, PlatformContext context, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public override Task DeleteResponseAsync(string responseId, PlatformContext context, CancellationToken cancellationToken = default) => Task.CompletedTask;
        public override Task<AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, PlatformContext context, int limit = 20, bool ascending = false, string? after = null, string? before = null, CancellationToken cancellationToken = default) => throw new ResourceNotFoundException(responseId);
        public override Task<IEnumerable<OutputItem?>> GetItemsAsync(IEnumerable<string> itemIds, PlatformContext context, CancellationToken cancellationToken = default) => Task.FromResult(Enumerable.Empty<OutputItem?>());
        public override Task<IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, PlatformContext context, CancellationToken cancellationToken = default) => Task.FromResult(Enumerable.Empty<string>());
    }
}
