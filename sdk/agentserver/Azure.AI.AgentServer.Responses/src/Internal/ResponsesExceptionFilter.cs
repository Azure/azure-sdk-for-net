// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            return ApiErrorFactory.PayloadValidation(ex);
        }
        catch (ResponseValidationException ex)
        {
            // Response validation errors are developer bugs — log full details but never expose to caller
            _logger.LogError(ex,
                "Response validation failed with {ErrorCount} error(s): {Errors}",
                ex.Errors.Count,
                string.Join("; ", ex.Errors.Select(e => $"{e.Path}: {e.Message}")));
            return ApiErrorFactory.ServerError();
        }
        catch (BadRequestException ex)
        {
            _logger.LogWarning(ex, "Invalid request");
            return ApiErrorFactory.InvalidRequest(ex.Message, code: ex.Code, param: ex.ParamName);
        }
        catch (ResourceNotFoundException ex)
        {
            _logger.LogWarning(ex, "Resource not found");
            return ApiErrorFactory.NotFound(ex.Message);
        }
        catch (ResponsesApiException ex)
        {
            _logger.LogWarning(ex, "API error");
            return ApiErrorFactory.FromApiException(ex);
        }
        catch (BadHttpRequestException ex)
        {
            // Framework-thrown bad request — log detail internally, expose safe message
            _logger.LogWarning(ex, "Invalid request (framework)");
            return ApiErrorFactory.InvalidRequest("The request was invalid.");
        }
        catch (ArgumentException ex)
        {
            // Framework argument validation — log detail internally, expose safe message
            _logger.LogWarning(ex, "Invalid argument");
            return ApiErrorFactory.InvalidRequest("The request contained an invalid parameter.");
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
            return ApiErrorFactory.ServerError();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception in endpoint handler");
            return ApiErrorFactory.ServerError();
        }
    }
}
