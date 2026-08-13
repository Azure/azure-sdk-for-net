// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// An <see cref="IResult"/> that writes an <see cref="ApiErrorResponse"/> as JSON,
/// exposing the error model for downstream enrichment (e.g., adding request_id to
/// additional_info before the response is written).
/// </summary>
internal sealed class ApiErrorResult : IResult
{
    /// <summary>
    /// Gets the error response model. This can be mutated (e.g., to add additional_info)
    /// before <see cref="ExecuteAsync"/> is called.
    /// </summary>
    internal ApiErrorResponse ErrorResponse { get; }

    /// <summary>
    /// Gets the HTTP status code for this error response.
    /// </summary>
    internal int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="ApiErrorResult"/>.
    /// </summary>
    internal ApiErrorResult(ApiErrorResponse errorResponse, int statusCode)
    {
        ErrorResponse = errorResponse;
        StatusCode = statusCode;
    }

    /// <inheritdoc/>
    public Task ExecuteAsync(HttpContext httpContext)
    {
        httpContext.Response.StatusCode = StatusCode;
        httpContext.Response.ContentType = "application/json";
        return JsonSerializer.SerializeAsync(
            httpContext.Response.Body,
            ErrorResponse,
            SharedJsonOptions.Instance);
    }
}
