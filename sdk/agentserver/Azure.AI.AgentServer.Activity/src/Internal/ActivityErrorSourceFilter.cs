// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Endpoint filter that catches exceptions from activity endpoints and sets
/// the <c>x-platform-error-source</c> and <c>x-platform-error-detail</c>
/// response headers before re-throwing to the ASP.NET pipeline.
/// </summary>
/// <remarks>
/// Classification rules:
/// <list type="bullet">
///   <item><b>user</b>: caller's input is invalid (BadRequest, ArgumentException).</item>
///   <item><b>platform</b>: exception tagged via <see cref="PlatformErrorMarker"/> by SDK
///     infrastructure code (for example outbound token acquisition).</item>
///   <item><b>upstream</b>: everything else (default — developer's handler code failed).</item>
/// </list>
/// </remarks>
internal sealed class ActivityErrorSourceFilter : IEndpointFilter
{
    private readonly ILogger<ActivityErrorSourceFilter> _logger;

    public ActivityErrorSourceFilter(ILogger<ActivityErrorSourceFilter> logger)
    {
        _logger = logger;
    }

    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        try
        {
            return await next(context).ConfigureAwait(false);
        }
        catch (BadHttpRequestException ex)
        {
            SetErrorSourceHeaders(context.HttpContext, PlatformHeaders.ErrorSourceUser);
            _logger.LogWarning(ex, "Invalid request (framework) in activity handler");
            throw;
        }
        catch (ArgumentException ex)
        {
            SetErrorSourceHeaders(context.HttpContext, PlatformHeaders.ErrorSourceUser);
            _logger.LogWarning(ex, "Invalid argument in activity handler");
            throw;
        }
        catch (OperationCanceledException) when (context.HttpContext.RequestAborted.IsCancellationRequested)
        {
            throw;
        }
        catch (Exception ex)
        {
            bool isPlatform = PlatformErrorMarker.IsTagged(ex);
            var source = isPlatform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            SetErrorSourceHeaders(context.HttpContext, source, isPlatform ? FormatErrorDetail(ex) : null);

            if (isPlatform)
            {
                _logger.LogError(ex, "Platform infrastructure failure in activity handler");
            }

            throw;
        }
    }

    private const int MaxErrorDetailLength = 2048;

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
            detail = string.Concat(detail.AsSpan(0, MaxErrorDetailLength - 14), "...[truncated]");
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
