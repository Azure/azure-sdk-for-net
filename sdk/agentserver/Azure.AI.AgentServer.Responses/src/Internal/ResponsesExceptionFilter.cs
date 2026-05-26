// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Endpoint filter that catches exceptions thrown during endpoint execution
/// and converts them to structured <see cref="ApiErrorResponse"/> responses.
/// Delegates all error construction to <see cref="ApiErrorFactory"/>.
/// </summary>
internal sealed class ResponsesExceptionFilter : IEndpointFilter
{
    private readonly ILogger<ResponsesExceptionFilter> _logger;

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesExceptionFilter"/>.
    /// </summary>
    public ResponsesExceptionFilter(ILogger<ResponsesExceptionFilter> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc/>
    public async ValueTask<object?> InvokeAsync(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        try
        {
            return await next(context);
        }
        catch (PayloadValidationException ex)
        {
            _logger.LogWarning(ex, "Payload validation failed with {ErrorCount} error(s)", ex.Errors.Count);
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.PayloadValidation(ex),
                PlatformHeaders.ErrorSourceUser);
        }
        catch (ResponseValidationException ex)
        {
            // Handler produced invalid output — developer bug (upstream)
            _logger.LogError(ex,
                "Response validation failed with {ErrorCount} error(s): {Errors}",
                ex.Errors.Count,
                string.Join("; ", ex.Errors.Select(e => $"{e.Path}: {e.Message}")));
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.ServerError(),
                PlatformHeaders.ErrorSourceUpstream);
        }
        catch (BadRequestException ex)
        {
            // Bad request — always caller's fault regardless of who throws it
            // (our validation, storage 400/409 mapped by StorageErrorMapper, handler rejection)
            _logger.LogWarning(ex, "Invalid request");
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.InvalidRequest(ex.Message, code: ex.Code, param: ex.ParamName),
                PlatformHeaders.ErrorSourceUser);
        }
        catch (ResourceNotFoundException ex)
        {
            // Resource doesn't exist — caller asked for something that isn't there
            _logger.LogWarning(ex, "Resource not found");
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.NotFound(ex.Message, code: ex.Code, param: ex.Param),
                PlatformHeaders.ErrorSourceUser);
        }
        catch (ResponsesApiException ex)
        {
            // Data flag set → platform (StorageErrorMapper 5xx, persistence infra failure)
            // Data flag absent → upstream (ThrowBadHandler, handler protocol violation)
            _logger.LogWarning(ex, "API error");
            RecordException(Activity.Current, ex);
            bool isPlatform = ex.Data.Contains(StorageErrorMapper.PlatformErrorDataKey);
            var source = isPlatform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.FromApiException(ex),
                source, isPlatform ? FormatErrorDetail(ex) : null);
        }
        catch (BadHttpRequestException ex)
        {
            // Framework-level bad request — malformed HTTP
            _logger.LogWarning(ex, "Invalid request (framework)");
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.InvalidRequest("The request was invalid."),
                PlatformHeaders.ErrorSourceUser);
        }
        catch (ArgumentException ex)
        {
            // Parameter binding failure — caller's input is wrong
            _logger.LogWarning(ex, "Invalid argument");
            RecordException(Activity.Current, ex);
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.InvalidRequest("The request contained an invalid parameter."),
                PlatformHeaders.ErrorSourceUser);
        }
        catch (OperationCanceledException) when (context.HttpContext.RequestAborted.IsCancellationRequested)
        {
            // Client disconnected — no response needed, no error classification
            return Results.StatusCode(499);
        }
        catch (OperationCanceledException ex)
        {
            // Non-client cancellation: Data flag set → platform (our infra timeout),
            // absent → upstream (handler's own CTS/timeout)
            _logger.LogError(ex, "Operation cancelled unexpectedly");
            RecordException(Activity.Current, ex);
            bool isPlatform = ex.Data.Contains(StorageErrorMapper.PlatformErrorDataKey);
            var source = isPlatform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.ServerError(),
                source, isPlatform ? FormatErrorDetail(ex) : null);
        }
        catch (Exception ex)
        {
            // All other exceptions: Data flag set → platform (tagged by storage pipeline),
            // absent → upstream (developer's handler code)
            _logger.LogError(ex, "Unhandled exception in endpoint handler");
            RecordException(Activity.Current, ex);
            bool isPlatform = ex.Data.Contains(StorageErrorMapper.PlatformErrorDataKey);
            var source = isPlatform
                ? PlatformHeaders.ErrorSourcePlatform
                : PlatformHeaders.ErrorSourceUpstream;
            return EnrichErrorResponse(context.HttpContext, ApiErrorFactory.ServerError(),
                source, isPlatform ? FormatErrorDetail(ex) : null);
        }
    }

    /// <summary>
    /// Maximum length for the <c>x-platform-error-detail</c> header value.
    /// Keeps the header within safe limits for reverse proxies and load balancers
    /// while preserving enough of the stack trace to be diagnostically useful.
    /// </summary>
    private const int MaxErrorDetailLength = 2048;

    /// <summary>
    /// Formats an exception for the <c>x-platform-error-detail</c> header.
    /// Unwraps <see cref="AggregateException"/> (which adds noise without diagnostic
    /// value), uses <see cref="Exception.ToString()"/> for full stack trace context,
    /// and truncates to <see cref="MaxErrorDetailLength"/>.
    /// </summary>
    private static string FormatErrorDetail(Exception ex)
    {
        // Unwrap AggregateException — they just wrap the real exception(s)
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

    /// <summary>
    /// Enriches an error <see cref="IResult"/> with request ID correlation and
    /// error source classification headers per container-image-spec §8.
    /// </summary>
    private static IResult EnrichErrorResponse(
        HttpContext httpContext,
        IResult result,
        string errorSource,
        string? errorDetail = null)
    {
        // Set error source classification headers
        httpContext.Response.OnStarting(state =>
        {
            var (ctx, source, detail) = ((HttpContext, string, string?))state;
            ctx.Response.Headers[PlatformHeaders.ErrorSource] = source;
            if (!string.IsNullOrEmpty(detail))
            {
                ctx.Response.Headers[PlatformHeaders.ErrorDetail] = detail;
            }

            return Task.CompletedTask;
        }, (httpContext, errorSource, errorDetail));

        // Enrich error body with request ID
        if (result is ApiErrorResult errorResult)
        {
            var requestId = GetRequestId(httpContext);
            if (!string.IsNullOrEmpty(requestId))
            {
                var error = errorResult.ErrorResponse.Error;
                if (!error.AdditionalInfo.ContainsKey("request_id"))
                {
                    error.AdditionalInfo["request_id"] = BinaryData.FromObjectAsJson(requestId);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Resolves the request ID from HttpContext.Items (set by RequestIdMiddleware in Core).
    /// </summary>
    private static string? GetRequestId(HttpContext httpContext)
    {
        if (httpContext.Items.TryGetValue(PlatformHeaders.RequestIdItemKey, out var value) && value is string s)
        {
            return s;
        }

        return null;
    }

    /// <summary>
    /// Records an exception on the given activity.
    /// </summary>
    internal static void RecordException(Activity? activity, Exception? exception)
    {
        if (activity is null || exception is null)
        {
            return;
        }

        activity.SetStatus(ActivityStatusCode.Error, exception.Message);

        // Error tags per responses protocol spec
        string errorCode = exception.GetType().FullName!;
        string errorMessage = exception.Message;
        activity.SetTag(ResponsesTracingConstants.Tags.ErrorCode, errorCode);
        activity.SetTag(ResponsesTracingConstants.Tags.ErrorMessage, errorMessage);

        // OTel semantic convention attributes
        activity.SetTag(ResponsesTracingConstants.Tags.OTelErrorType, errorCode);
        activity.SetTag(ResponsesTracingConstants.Tags.OTelStatusDescription, errorMessage);

        // Add exception event per OTel semantic conventions
        var tags = new ActivityTagsCollection
        {
            { "exception.type", exception.GetType().FullName! },
            { "exception.message", exception.Message },
            { "exception.stacktrace", exception.ToString() },
        };
        activity.AddEvent(new ActivityEvent("exception", tags: tags));
    }
}
