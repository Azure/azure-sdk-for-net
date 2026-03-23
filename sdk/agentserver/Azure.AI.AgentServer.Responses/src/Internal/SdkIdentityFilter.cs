// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Endpoint filter that sets the <c>x-platform-server</c> identity header on every response.
/// If the header already has a value (set by another middleware or hosting layer),
/// the SDK appends its identity with a <c>; </c> separator.
/// When <see cref="ResponsesServerOptions.AdditionalServerIdentity"/> is configured,
/// it is appended after the SDK identity.
/// </summary>
internal sealed class SdkIdentityFilter : IEndpointFilter
{
    /// <summary>The header name used for SDK identity.</summary>
    internal const string HeaderName = "x-platform-server";

    /// <summary>
    /// Cached SDK identity header value:
    /// <c>azure-ai-agentserver-responses/{version} (dotnet/{runtime-version})</c>
    /// </summary>
    private static readonly string s_sdkIdentityValue = BuildSdkIdentityValue();

    /// <summary>
    /// Resolved header value (SDK identity + optional additional identity), computed once.
    /// </summary>
    private readonly string _identityValue;

    public SdkIdentityFilter(IOptions<ResponsesServerOptions> options)
    {
        var additionalIdentity = options.Value.AdditionalServerIdentity;
        _identityValue = string.IsNullOrEmpty(additionalIdentity)
            ? s_sdkIdentityValue
            : $"{s_sdkIdentityValue}; {additionalIdentity}";
    }

    /// <inheritdoc/>
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var httpContext = context.HttpContext;

        // Set the identity header before calling next, so it's present even on error responses.
        // Check if another layer has already set the header (composability — FR-002).
        if (httpContext.Response.Headers.TryGetValue(HeaderName, out var existing)
            && !string.IsNullOrEmpty(existing.ToString()))
        {
            httpContext.Response.Headers[HeaderName] = $"{existing}; {_identityValue}";
        }
        else
        {
            httpContext.Response.Headers[HeaderName] = _identityValue;
        }

        return await next(context);
    }

    /// <summary>
    /// Builds the SDK identity header value from the SDK assembly version and .NET runtime version.
    /// </summary>
    private static string BuildSdkIdentityValue()
    {
        var sdkVersion = typeof(SdkIdentityFilter).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
            ?? typeof(SdkIdentityFilter).Assembly.GetName().Version?.ToString()
            ?? "0.0.0";

        // Strip metadata suffix (e.g., "+abc123") if present from informational version
        var plusIndex = sdkVersion.IndexOf('+');
        if (plusIndex >= 0)
        {
            sdkVersion = sdkVersion[..plusIndex];
        }

        var runtimeVersion = Environment.Version;

        return $"azure-ai-agentserver-responses/{sdkVersion} (dotnet/{runtimeVersion.Major}.{runtimeVersion.Minor})";
    }
}
