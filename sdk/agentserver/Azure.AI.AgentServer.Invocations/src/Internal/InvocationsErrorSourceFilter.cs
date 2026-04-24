// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>
/// Endpoint filter that catches exceptions from invocation endpoints and sets
/// the <c>x-platform-error-source</c> and <c>x-platform-error-detail</c>
/// response headers per container-image-spec §8 before re-throwing to
/// the ASP.NET pipeline.
/// </summary>
/// <remarks>
/// Unlike the Responses protocol (which converts exceptions to structured JSON),
/// Invocations lets the developer's handler fully own the response format. This
/// filter only adds error classification headers — it does not change the response
/// body or status code. The exception is re-thrown so the host's exception handler
/// (or developer middleware) can produce the appropriate response body.
///
/// Classification rules:
/// <list type="bullet">
///   <item><b>user</b>: caller's input is invalid (BadRequest, ArgumentException).</item>
///   <item><b>platform</b>: exception tagged with <c>PlatformErrorDataKey</c> in
///     <see cref="Exception.Data"/> by SDK infrastructure code.</item>
///   <item><b>upstream</b>: everything else (default — developer's handler code failed).</item>
/// </list>
/// </remarks>
internal sealed class InvocationsErrorSourceFilter : IEndpointFilter
{
    /// <summary>
    /// Exception.Data key used to identify platform infrastructure exceptions.
    /// Matches the key set by storage pipeline code in the Responses package.
    /// </summary>
    private const string PlatformErrorDataKey = "Azure.AI.AgentServer.PlatformError";

    private readonly ILogger<InvocationsErrorSourceFilter> _logger;

    public InvocationsErrorSourceFilter(ILogger<InvocationsErrorSourceFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (BadHttpRequestException ex)
        {
            // Framework-level bad request — caller's fault
            SetErrorSourceHeaders(context.HttpContext, PlatformHeaders.ErrorSourceUser);
            _logger.LogWarning(ex, "Invalid request (framework) in invocation handler");
            throw;
        }
        catch (ArgumentException ex)
        {
            // Parameter binding failure — caller's input is wrong
            SetErrorSourceHeaders(context.HttpContext, PlatformHeaders.ErrorSourceUser);
            _logger.LogWarning(ex, "Invalid argument in invocation handler");
            throw;
        }
        catch (OperationCanceledException) when (context.HttpContext.RequestAborted.IsCancellationRequested)
        {
            // Client disconnected — no headers needed
            throw;
        }
        catch (Exception ex)
        {
            // Data flag set → platform (SDK infra tagged the exception)
            // Data flag absent → upstream (developer's handler code)
            bool isPlatform = ex.Data.Contains(PlatformErrorDataKey);
            var source = isPlatform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            SetErrorSourceHeaders(context.HttpContext, source, isPlatform ? FormatErrorDetail(ex) : null);

            if (isPlatform)
            {
                _logger.LogError(ex, "Platform infrastructure failure in invocation handler");
            }

            throw;
        }
    }

    /// <summary>
    /// Maximum length for the <c>x-platform-error-detail</c> header value.
    /// </summary>
    private const int MaxErrorDetailLength = 2048;

    /// <summary>
    /// Formats an exception for the <c>x-platform-error-detail</c> header.
    /// Unwraps <see cref="AggregateException"/>, uses <see cref="Exception.ToString()"/>
    /// for full stack trace context, and truncates to <see cref="MaxErrorDetailLength"/>.
    /// </summary>
    private static string FormatErrorDetail(Exception ex)
    {
        var unwrapped = ex;
        if (ex is AggregateException agg)
        {
            unwrapped = agg.InnerExceptions.Count == 1
                ? agg.InnerExceptions[0]
                : agg.Flatten();
        }

        var detail = unwrapped.ToString();

        if (detail.Length > MaxErrorDetailLength)
        {
            detail = string.Concat(detail.AsSpan(0, MaxErrorDetailLength), "...[truncated]");
        }

        return detail;
    }

    private static void SetErrorSourceHeaders(HttpContext httpContext, string source, string? detail = null)
    {
        httpContext.Response.OnStarting(state =>
        {
            var (ctx, src, det) = ((HttpContext, string, string?))state;
            ctx.Response.Headers[PlatformHeaders.ErrorSource] = src;
            if (!string.IsNullOrEmpty(det))
            {
                ctx.Response.Headers[PlatformHeaders.ErrorDetail] = det;
            }

            return Task.CompletedTask;
        }, (httpContext, source, detail));
    }
}
