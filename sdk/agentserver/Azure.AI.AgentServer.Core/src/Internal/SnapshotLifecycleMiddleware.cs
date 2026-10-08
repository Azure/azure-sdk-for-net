// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Internal;

internal sealed class SnapshotLifecycleMiddleware : IMiddleware
{
    private const string SessionIdEnvironmentVariable = "FOUNDRY_AGENT_SESSION_ID";
    private const string BeforeSnapshotPath = "/_agent/before-snapshot";
    private const string AfterRestorePath = "/_agent/after-restore";
    private const string SuccessResponse = """{"status":"ok"}""";
    private const string InvalidRequestResponse =
        """{"error":{"code":"invalid_request","message":"Invalid lifecycle request."}}""";
    private const string BeforeSnapshotFailedResponse =
        """{"error":{"code":"before_snapshot_failed","message":"The before-snapshot hook failed."}}""";
    private const string AfterRestoreFailedResponse =
        """{"error":{"code":"after_restore_failed","message":"The after-restore hook failed."}}""";
    private const string SessionMismatchResponse =
        """{"error":{"code":"session_mismatch","message":"The restored process is already assigned to another session."}}""";

    private readonly SnapshotLifecycleCoordinator _coordinator;

    public SnapshotLifecycleMiddleware(SnapshotLifecycleCoordinator coordinator)
    {
        _coordinator = coordinator;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!HttpMethods.IsPost(context.Request.Method))
        {
            await next(context).ConfigureAwait(false);
            return;
        }

        if (context.Request.Path.Equals(BeforeSnapshotPath))
        {
            await HandleBeforeSnapshotAsync(context).ConfigureAwait(false);
            return;
        }

        if (context.Request.Path.Equals(AfterRestorePath))
        {
            await HandleAfterRestoreAsync(context).ConfigureAwait(false);
            return;
        }

        await next(context).ConfigureAwait(false);
    }

    private async Task HandleBeforeSnapshotAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
        {
            await WriteJsonAsync(
                context.Response,
                InvalidRequestResponse,
                StatusCodes.Status415UnsupportedMediaType).ConfigureAwait(false);
            return;
        }

        try
        {
            using var document = await JsonDocument.ParseAsync(
                context.Request.Body,
                cancellationToken: context.RequestAborted).ConfigureAwait(false);
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                await WriteJsonAsync(
                    context.Response,
                    InvalidRequestResponse,
                    StatusCodes.Status400BadRequest).ConfigureAwait(false);
                return;
            }
        }
        catch (JsonException)
        {
            await WriteJsonAsync(
                context.Response,
                InvalidRequestResponse,
                StatusCodes.Status400BadRequest).ConfigureAwait(false);
            return;
        }

        try
        {
            await _coordinator.BeforeSnapshotAsync().ConfigureAwait(false);
            await WriteJsonAsync(
                context.Response,
                SuccessResponse,
                StatusCodes.Status200OK).ConfigureAwait(false);
        }
        catch (Exception) when (!context.RequestAborted.IsCancellationRequested)
        {
            await WriteJsonAsync(
                context.Response,
                BeforeSnapshotFailedResponse,
                StatusCodes.Status500InternalServerError).ConfigureAwait(false);
        }
    }

    private async Task HandleAfterRestoreAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
        {
            await WriteJsonAsync(
                context.Response,
                InvalidRequestResponse,
                StatusCodes.Status415UnsupportedMediaType).ConfigureAwait(false);
            return;
        }

        AgentRestoreContext? restoreContext;
        try
        {
            restoreContext = await ParseRestoreContextAsync(context.Request).ConfigureAwait(false);
        }
        catch (JsonException)
        {
            await WriteJsonAsync(
                context.Response,
                InvalidRequestResponse,
                StatusCodes.Status400BadRequest).ConfigureAwait(false);
            return;
        }

        if (restoreContext is null)
        {
            await WriteJsonAsync(
                context.Response,
                InvalidRequestResponse,
                StatusCodes.Status400BadRequest).ConfigureAwait(false);
            return;
        }

        try
        {
            var result = await _coordinator.AfterRestoreAsync(restoreContext).ConfigureAwait(false);
            await WriteJsonAsync(
                context.Response,
                result == AfterRestoreResult.SessionMismatch
                    ? SessionMismatchResponse
                    : SuccessResponse,
                result == AfterRestoreResult.SessionMismatch
                    ? StatusCodes.Status409Conflict
                    : StatusCodes.Status200OK).ConfigureAwait(false);
        }
        catch (Exception) when (!context.RequestAborted.IsCancellationRequested)
        {
            await WriteJsonAsync(
                context.Response,
                AfterRestoreFailedResponse,
                StatusCodes.Status500InternalServerError).ConfigureAwait(false);
        }
    }

    private static async Task<AgentRestoreContext?> ParseRestoreContextAsync(HttpRequest request)
    {
        using var document = await JsonDocument.ParseAsync(
            request.Body,
            cancellationToken: request.HttpContext.RequestAborted).ConfigureAwait(false);
        var root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object
            || !root.TryGetProperty("session_context", out var sessionContext)
            || sessionContext.ValueKind != JsonValueKind.Object
            || !TryGetRequiredString(sessionContext, "session_id", out var sessionId)
            || !TryGetRequiredString(sessionContext, "restore_id", out var restoreId))
        {
            return null;
        }

        var overrides = new Dictionary<string, string>(StringComparer.Ordinal);
        if (sessionContext.TryGetProperty("session_env_overrides", out var overridesElement))
        {
            if (overridesElement.ValueKind != JsonValueKind.Object)
            {
                return null;
            }

            foreach (var property in overridesElement.EnumerateObject())
            {
                var value = property.Value.ValueKind == JsonValueKind.String
                    ? property.Value.GetString()
                    : null;
                if (!IsValidEnvironmentVariableName(property.Name)
                    || string.IsNullOrEmpty(value)
                    || value.Contains('\0')
                    || !overrides.TryAdd(property.Name, value))
                {
                    return null;
                }
            }
        }

        if (overrides.TryGetValue("PORT", out var port)
            && (!int.TryParse(port, out var parsedPort) || parsedPort is < 1 or > 65535))
        {
            return null;
        }

        if (overrides.TryGetValue(SessionIdEnvironmentVariable, out var overriddenSessionId)
            && !string.Equals(overriddenSessionId, sessionId, StringComparison.Ordinal))
        {
            return null;
        }

        return new AgentRestoreContext(sessionId, restoreId, overrides);
    }

    private static bool TryGetRequiredString(
        JsonElement parent,
        string propertyName,
        out string value)
    {
        value = string.Empty;
        if (!parent.TryGetProperty(propertyName, out var property)
            || property.ValueKind != JsonValueKind.String)
        {
            return false;
        }

        value = property.GetString()!;
        return !string.IsNullOrWhiteSpace(value) && !value.Contains('\0');
    }

    private static bool IsValidEnvironmentVariableName(string name) =>
        name.Length > 0 && !name.Contains('=') && !name.Contains('\0');

    private static Task WriteJsonAsync(HttpResponse response, string body, int statusCode)
    {
        response.StatusCode = statusCode;
        response.ContentType = "application/json";
        return response.WriteAsync(body);
    }
}
