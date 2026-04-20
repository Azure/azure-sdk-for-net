// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// Middleware that injects the <c>x-platform-server</c> header on all HTTP responses,
/// identifying the server SDK stack — hosting version, protocol versions, language, and runtime.
/// Protocol packages register their identity segments via <see cref="ServerVersionRegistry"/>
/// during route mapping, and this middleware composes the final header value.
/// </summary>
internal sealed class ServerVersionMiddleware : IMiddleware
{
    private const string HeaderName = "x-platform-server";
    private readonly string _headerValue;

    /// <summary>
    /// Initializes a new instance of <see cref="ServerVersionMiddleware"/>.
    /// </summary>
    public ServerVersionMiddleware(
        IOptions<AgentHostOptions> options,
        ServerVersionRegistry registry)
    {
        var version = typeof(ServerVersionMiddleware).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "0.0.0";

        // Trim commit hash suffix if present (e.g., "1.0.0-beta.1+abc123" → "1.0.0-beta.1")
        var plusIdx = version.IndexOf('+');
        if (plusIdx >= 0)
        {
            version = version[..plusIdx];
        }

        var runtimeVersion = Environment.Version;
        var baseIdentity = $"azure-ai-agentserver/{version} (dotnet/{runtimeVersion.Major}.{runtimeVersion.Minor})";

        // Compose: hosting identity + protocol identities + optional additional identity
        var segments = new List<string> { baseIdentity };
        segments.AddRange(registry.GetSegments());

        var additional = options.Value.AdditionalServerIdentity;
        if (!string.IsNullOrEmpty(additional))
        {
            segments.Add(additional);
        }

        _headerValue = string.Join("; ", segments);
    }

    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Response.OnStarting(() =>
        {
            context.Response.Headers[HeaderName] = _headerValue;
            return Task.CompletedTask;
        });

        await next(context);
    }
}
