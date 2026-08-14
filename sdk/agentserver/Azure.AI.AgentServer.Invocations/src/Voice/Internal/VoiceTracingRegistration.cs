// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenTelemetry.Instrumentation.AspNetCore;

namespace Azure.AI.AgentServer.Invocations.Voice;

internal static class VoiceTracingRegistration
{
    internal static void Add(IServiceCollection services)
    {
        services.PostConfigure<AspNetCoreTraceInstrumentationOptions>(options =>
        {
            var applicationFilter = options.Filter;
            options.Filter = httpContext =>
                (applicationFilter?.Invoke(httpContext) ?? true) &&
                !IsVoiceWebSocketUpgrade(httpContext);
        });
        services.TryAddSingleton<VoiceRouteRegistry>();
    }

    private static bool IsVoiceWebSocketUpgrade(HttpContext httpContext)
    {
        var request = httpContext.Request;
        return HttpMethods.IsGet(request.Method) &&
            httpContext.RequestServices.GetRequiredService<VoiceRouteRegistry>()
                .Contains(request.Path) &&
            HeaderContainsToken(request.Headers.Connection, "upgrade") &&
            HeaderContainsToken(request.Headers.Upgrade, "websocket") &&
            HasValidWebSocketKey(request.Headers.SecWebSocketKey) &&
            HeaderContainsToken(request.Headers.SecWebSocketVersion, "13");
    }

    private static bool HasValidWebSocketKey(
        Microsoft.Extensions.Primitives.StringValues values)
    {
        if (values.Count != 1 || values[0] is not { } value)
        {
            return false;
        }

        Span<byte> decoded = stackalloc byte[16];
        return Convert.TryFromBase64String(value, decoded, out var bytesWritten) &&
            bytesWritten == decoded.Length;
    }

    private static bool HeaderContainsToken(
        Microsoft.Extensions.Primitives.StringValues values,
        string expected)
    {
        foreach (var value in values)
        {
            if (value is null)
            {
                continue;
            }
            foreach (var token in value.Split(','))
            {
                if (string.Equals(token.Trim(), expected, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

internal sealed class VoiceRouteRegistry
{
    private readonly HashSet<string> _paths = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _gate = new();

    internal void Add(string path)
    {
        lock (_gate)
        {
            _paths.Add(path);
        }
    }

    internal bool Contains(PathString path)
    {
        lock (_gate)
        {
            return path.Value is { } value && _paths.Contains(value);
        }
    }
}