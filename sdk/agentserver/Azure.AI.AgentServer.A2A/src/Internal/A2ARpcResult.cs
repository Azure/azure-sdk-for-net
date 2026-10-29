// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using global::A2A;
using global::A2A.AspNetCore;
using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed class A2ARpcResult(IA2ARequestHandler handler, AgentCard card) : IResult
{
    internal const string SourceName = "Azure.AI.AgentServer.A2A";
    private static readonly ActivitySource Source = new(SourceName, typeof(A2ARpcResult).Assembly.GetName().Version?.ToString());

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        Stream originalBody = httpContext.Request.Body;
        using var body = new MemoryStream();
        await originalBody.CopyToAsync(body, httpContext.RequestAborted).ConfigureAwait(false);
        body.Position = 0;
        httpContext.Request.Body = body;
        try
        {
            await ExecuteRequestAsync(httpContext).ConfigureAwait(false);
        }
        finally
        {
            httpContext.Request.Body = originalBody;
        }
    }

    private async Task ExecuteRequestAsync(HttpContext httpContext)
    {
        var request = httpContext.Request;
        Dictionary<string, object?> tags = await ReadTagsAsync(request).ConfigureAwait(false);
        string? method = tags.GetValueOrDefault("a2a.method.name") as string;
        bool invocation = FoundryEnvironment.IsHosted && method is "SendMessage" or "SendStreamingMessage";

        using var invoke = invocation
            ? Source.StartActivity($"invoke_agent {FoundryEnvironment.AgentName}", ActivityKind.Internal)
            : null;
        if (invoke is not null)
        {
            foreach (var tag in tags)
            {
                invoke.SetTag(tag.Key, tag.Value);
            }

            invoke.SetTag("gen_ai.operation.name", "invoke_agent");
            invoke.SetTag("gen_ai.system", "azure.ai.agentserver");
            invoke.SetTag("gen_ai.agent.name", FoundryEnvironment.AgentName);
            invoke.SetTag("gen_ai.agent.version", FoundryEnvironment.AgentVersion);
            invoke.SetTag("gen_ai.agent.id", FoundryEnvironment.AgentId);
            invoke.SetTag("microsoft.foundry.project.id", FoundryEnvironment.ProjectArmId);
            invoke.SetTag("microsoft.session.id", FoundryEnvironment.SessionId);
        }

        tags["gen_ai.agent.name"] = card.Name;
        tags["gen_ai.agent.description"] = card.Description;
        tags["gen_ai.agent.version"] = card.Version;
        using var operation = method is null ? null : Source.StartActivity(
            method, ActivityKind.Server, System.Diagnostics.Activity.Current?.Context ?? default, tags: tags);
        if (tags.GetValueOrDefault("gen_ai.conversation.id") is string contextId)
        {
            operation?.SetBaggage("azure.ai.agentserver.conversation_id", contextId);
            invoke?.SetBaggage("azure.ai.agentserver.conversation_id", contextId);
        }

        var originalBody = httpContext.Response.Body;
        using var observer = new A2AResponseObserver(
            httpContext, method, operation, invoke, tags.ContainsKey("a2a.task.id"));
        using var observedBody = new ObservingWriteStream(originalBody, observer);
        httpContext.Response.Body = observedBody;
        var previousScope = A2ATaskScope.Current;
        string? authenticatedUser = httpContext.User.Identity?.IsAuthenticated == true
            ? httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? httpContext.User.FindFirst("sub")?.Value ?? httpContext.User.Identity.Name
            : null;
        A2ATaskScope.Current = new A2ATaskScope(tags.GetValueOrDefault("a2a.tenant") as string, authenticatedUser);
        try
        {
            var result = await A2AJsonRpcProcessor.ProcessRequestAsync(
                handler, request, httpContext.RequestAborted).ConfigureAwait(false);
            await result.ExecuteAsync(httpContext).ConfigureAwait(false);
            observer.Complete();
            if (httpContext.Response.StatusCode >= 400)
            {
                observer.RecordError(httpContext.Response.StatusCode.ToString(System.Globalization.CultureInfo.InvariantCulture));
            }
        }
        catch (OperationCanceledException) when (httpContext.RequestAborted.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception exception)
        {
            observer.RecordError(exception.GetType().FullName!);
            operation?.AddEvent(new ActivityEvent("exception", tags: new ActivityTagsCollection
            {
                ["exception.type"] = exception.GetType().FullName,
            }));
            throw;
        }
        finally
        {
            A2ATaskScope.Current = previousScope;
            httpContext.Response.Body = originalBody;
        }
    }

    private static async Task<Dictionary<string, object?>> ReadTagsAsync(HttpRequest request)
    {
        var tags = new Dictionary<string, object?>();
        try
        {
            using var document = await JsonDocument.ParseAsync(
                request.Body, cancellationToken: request.HttpContext.RequestAborted).ConfigureAwait(false);
            var root = document.RootElement;
            string? method = String(root, "method");
            if (method is null)
            {
                return tags;
            }

            tags["a2a.method.name"] = method;
            tags["a2a.protocol.version"] = request.Headers["A2A-Version"].FirstOrDefault()
                ?? request.Query["a2a-version"].FirstOrDefault() ?? "1.0";
            var parameters = Property(root, "params");
            var message = Property(parameters, "message");
            Add("a2a.message.id", String(message, "messageId"));
            Add("a2a.tenant", String(parameters, "tenant"));
            Add("gen_ai.conversation.id", String(message, "contextId") ?? String(parameters, "contextId"));
            Add("a2a.task.id", String(message, "taskId") ?? String(parameters, "taskId")
                ?? (method is "GetTask" or "CancelTask" or "SubscribeToTask" ? String(parameters, "id") : null));
            var references = Property(message, "referenceTaskIds");
            if (references.ValueKind == JsonValueKind.Array)
            {
                tags["a2a.message.reference_task_ids"] = references.EnumerateArray()
                    .Where(value => value.ValueKind == JsonValueKind.String && !string.IsNullOrEmpty(value.GetString()))
                    .Select(value => value.GetString()!).ToArray();
            }
        }
        catch (JsonException exception)
        {
            request.HttpContext.RequestServices.GetRequiredService<ILogger<A2ARpcResult>>()
                .LogDebug(exception, "A2A request could not be observed; the native transport will validate it");
        }
        finally
        {
            request.Body.Position = 0;
        }

        return tags;

        void Add(string name, string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                tags[name] = value;
            }
        }
    }

    internal static JsonElement Property(JsonElement value, string name) =>
        value.ValueKind == JsonValueKind.Object && value.TryGetProperty(name, out var property) ? property : default;

    internal static string? String(JsonElement value, string name)
    {
        var property = Property(value, name);
        return property.ValueKind == JsonValueKind.String && property.GetString() is { Length: > 0 } text ? text : null;
    }
}
