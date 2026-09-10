// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Internal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Extension methods for <see cref="IEndpointRouteBuilder"/> to map
/// the Responses API routes.
/// </summary>
public static class ResponsesServerEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Maps the Responses API routes to the endpoint routing pipeline.
    /// </summary>
    /// <param name="endpoints">The endpoint route builder to map routes on.</param>
    /// <param name="prefix">Optional route prefix (e.g., "/openai/v1"). Default: empty (routes at /responses).</param>
    /// <returns>A <see cref="RouteGroupBuilder"/> for further endpoint configuration.</returns>
    public static RouteGroupBuilder MapResponsesServer(
        this IEndpointRouteBuilder endpoints,
        string? prefix = null)
    {
        // Fail-fast: verify ResponseHandler is registered (S-004)
        var handler = endpoints.ServiceProvider.GetService<ResponseHandler>();
        if (handler is null)
        {
            throw new InvalidOperationException(
                "No ResponseHandler implementation is registered. " +
                "Call AddResponsesServer() and register an ResponseHandler implementation " +
                "before calling MapResponsesServer().");
        }

        ValidateResilientComposition(endpoints.ServiceProvider);

        var groupPrefix = string.IsNullOrEmpty(prefix) ? string.Empty : prefix.TrimEnd('/');
        var group = endpoints.MapGroup(groupPrefix);

        // Register Responses protocol identity with the version registry (if available)
        var registry = endpoints.ServiceProvider.GetService<ServerVersionRegistry>();
        if (registry is not null)
        {
            registry.Register(ServerVersionRegistry.BuildIdentityString(
                "azure-ai-agentserver-responses",
                typeof(ResponsesServerEndpointRouteBuilderExtensions).Assembly));
        }

        group.AddEndpointFilter<SessionIdResponseHeaderFilter>();
        group.AddEndpointFilter<ResponsesExceptionFilter>();

        group.MapPost("/responses", async (HttpContext httpContext, ResponseEndpointHandler handler) =>
        {
            return await handler.CreateResponseAsync(httpContext);
        });

        group.MapGet("/responses/{responseId}", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.GetResponseAsync(httpContext, responseId);
        });

        group.MapPost("/responses/{responseId}/cancel", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.CancelResponseAsync(httpContext, responseId);
        });

        group.MapDelete("/responses/{responseId}", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.DeleteResponseAsync(httpContext, responseId);
        });

        group.MapGet("/responses/{responseId}/input_items", async (HttpContext httpContext, string responseId, ResponseEndpointHandler handler) =>
        {
            return await handler.GetInputItemsAsync(httpContext, responseId);
        });

        group.WithTags("Responses");

        return group;
    }

    /// <summary>
    /// Fails loudly at startup when resilient background responses are enabled but the composed
    /// persistence providers cannot survive a process restart. Enabling
    /// <see cref="ResponsesServerOptions.ResilientBackground"/> promises that a background response
    /// interrupted by a crash or graceful shutdown is re-invoked after the sandbox auto-recovers;
    /// that promise cannot be kept if response state lives only in memory. Rather than silently
    /// downgrading to weaker durability, the server refuses to start and names the offending
    /// provider so the misconfiguration is caught before any request is accepted.
    /// </summary>
    private static void ValidateResilientComposition(IServiceProvider services)
    {
        var options = services.GetService<Microsoft.Extensions.Options.IOptions<ResponsesServerOptions>>()?.Value;
        if (options is null || (!options.ResilientBackground && !options.SteerableConversations))
        {
            return;
        }

        if (options.ResilientBackground)
        {
            var provider = services.GetService<ResponsesProvider>();
            if (provider is null)
            {
                throw new InvalidOperationException(
                    "ResilientBackground is enabled but no ResponsesProvider is registered. " +
                    "Call AddResponsesServer() (which registers a durable file-backed provider for " +
                    "resilient local operation) or register a resilient-capable ResponsesProvider " +
                    "before calling MapResponsesServer().");
            }

            if (provider is Internal.InMemoryResponsesProvider)
            {
                throw new InvalidOperationException(
                    "ResilientBackground is enabled but the registered ResponsesProvider is the " +
                    "in-memory provider, whose state does not survive a process restart. Resilient " +
                    "background responses require a durable provider (the SDK selects a file-backed " +
                    "provider automatically for local resilient operation, or a hosted storage " +
                    "provider in a hosted environment). Register a durable ResponsesProvider or " +
                    "disable ResilientBackground.");
            }
        }

        // The resilient/steerable request paths run INSIDE a Core @task / @multi_turn_task and
        // resolve ITaskInvoker per request. AddResponsesServer composes the Core task subsystem
        // (AddResilientTasks) in both local and hosted environments — independent of how options are set —
        // so the historical "options enabled via a separate configuration path leaves ITaskInvoker
        // unregistered" desync can no longer occur. This defensive guard remains as a safety net: if a
        // consumer somehow removed the task subsystem while a resilient/steerable option is enabled, it
        // fails loud at startup rather than as a per-request 500.
        if ((options.ResilientBackground || options.SteerableConversations)
            && services.GetService<Core.Tasks.ITaskInvoker>() is null)
        {
            throw new InvalidOperationException(
                "ResilientBackground/SteerableConversations is enabled but the Core resilient-task " +
                "subsystem (ITaskInvoker) is not registered. AddResponsesServer() composes it for both " +
                "local and hosted hosts; if you removed or replaced the task subsystem registration, restore it " +
                "or disable the resilient/steerable options.");
        }
    }
}
