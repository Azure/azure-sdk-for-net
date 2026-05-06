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
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.PayloadValidation(ex));
        }
        catch (ResponseValidationException ex)
        {
            // Response validation errors are developer bugs — log full details but never expose to caller
            _logger.LogError(ex,
                "Response validation failed with {ErrorCount} error(s): {Errors}",
                ex.Errors.Count,
                string.Join("; ", ex.Errors.Select(e => $"{e.Path}: {e.Message}")));
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.ServerError());
        }
        catch (BadRequestException ex)
        {
            _logger.LogWarning(ex, "Invalid request");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.InvalidRequest(ex.Message, code: ex.Code, param: ex.ParamName));
        }
        catch (ResourceNotFoundException ex)
        {
            _logger.LogWarning(ex, "Resource not found");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.NotFound(ex.Message, code: ex.Code, param: ex.Param));
        }
        catch (ResponsesApiException ex)
        {
            _logger.LogWarning(ex, "API error");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.FromApiException(ex));
        }
        catch (BadHttpRequestException ex)
        {
            // Framework-thrown bad request — log detail internally, expose safe message
            _logger.LogWarning(ex, "Invalid request (framework)");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.InvalidRequest("The request was invalid."));
        }
        catch (ArgumentException ex)
        {
            // Framework argument validation — log detail internally, expose safe message
            _logger.LogWarning(ex, "Invalid argument");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.InvalidRequest("The request contained an invalid parameter."));
        }
        catch (OperationCanceledException) when (context.HttpContext.RequestAborted.IsCancellationRequested)
        {
            // Client disconnected — no response needed
            return Results.StatusCode(499);
        }
        catch (OperationCanceledException ex)
        {
            // Application-level cancellation (timeout, explicit cancel) — treat as server error
            _logger.LogError(ex, "Operation cancelled unexpectedly");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.ServerError());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception in endpoint handler");
            RecordException(Activity.Current, ex);
            return EnrichWithRequestId(context.HttpContext, ApiErrorFactory.ServerError());
        }
    }

    /// <summary>
    /// Wraps an error <see cref="IResult"/> so that <c>error.additional_info.request_id</c>
    /// is set to the resolved <c>x-request-id</c> value from the current request context.
    /// Only applies if the result is a JSON <see cref="ApiErrorResponse"/> and the property
    /// is not already set.
    /// </summary>
    private static IResult EnrichWithRequestId(HttpContext httpContext, IResult result)
    {
        if (result is not ApiErrorResult errorResult)
        {
            return result;
        }

        var requestId = GetRequestId(httpContext);
        if (string.IsNullOrEmpty(requestId))
        {
            return result;
        }

        var error = errorResult.ErrorResponse.Error;
        if (!error.AdditionalInfo.ContainsKey("request_id"))
        {
            error.AdditionalInfo["request_id"] = BinaryData.FromObjectAsJson(requestId);
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
