// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Exception that wraps a fully-formed <see cref="Models.Error"/> model and an HTTP status code.
/// Thrown when code needs to surface a structured API error that serializes directly
/// to <see cref="ApiErrorResponse"/>. Maps to the specified <see cref="StatusCode"/>.
/// </summary>
public class ResponsesApiException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesApiException"/> with an
    /// <see cref="Models.Error"/> model and HTTP status code.
    /// </summary>
    /// <param name="error">The structured error to return in the API response body.</param>
    /// <param name="statusCode">The HTTP status code to return.</param>
    public ResponsesApiException(Error error, int statusCode)
        : base(error.Message)
    {
        Error = error;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ResponsesApiException"/> with an
    /// <see cref="Models.Error"/> model, HTTP status code, and inner exception.
    /// </summary>
    /// <param name="error">The structured error to return in the API response body.</param>
    /// <param name="statusCode">The HTTP status code to return.</param>
    /// <param name="innerException">The exception that caused this error.</param>
    public ResponsesApiException(Error error, int statusCode, Exception innerException)
        : base(error.Message, innerException)
    {
        Error = error;
        StatusCode = statusCode;
    }

    /// <summary>
    /// Gets the structured error model to serialize in the API response body.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Gets the HTTP status code to return.
    /// </summary>
    public int StatusCode { get; }
}
