// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Maps HTTP error responses from the Foundry storage API to SDK exceptions.
/// </summary>
internal static class StorageErrorMapper
{
    /// <summary>
    /// Reads the HTTP status code of <paramref name="response"/> and throws the appropriate
    /// SDK exception if the response indicates an error condition.
    /// Structured upstream error information is preserved in the thrown exception where
    /// supported by the exception type. For 400, 404, and 409 responses, the thrown
    /// exception preserves the upstream message, code, and param values. For other
    /// non-success responses, the thrown <see cref="ResponsesApiException"/> also includes
    /// the upstream error type when present.
    /// </summary>
    /// <param name="response">The Azure.Core HTTP response to check.</param>
    /// <exception cref="ResourceNotFoundException">Thrown for 404 responses.</exception>
    /// <exception cref="BadRequestException">Thrown for 400 and 409 responses.</exception>
    /// <exception cref="ResponsesApiException">Thrown for all other non-success responses (5xx, etc.).</exception>
    public static void ThrowIfError(Response response)
    {
        if (!response.IsError)
            return;

        var status = response.Status;
        var errorInfo = ExtractErrorInfo(response);

        switch (status)
        {
            case 404:
                throw new ResourceNotFoundException(errorInfo.Message, errorInfo.Code, errorInfo.Param);
            case 400:
            case 409:
                throw new BadRequestException(errorInfo.Message, errorInfo.Code, errorInfo.Param);
            default:
                var error = new Error(errorInfo.Code ?? "storage_error", errorInfo.Message)
                {
                    Param = errorInfo.Param,
                    Type = errorInfo.Type ?? "server_error",
                };
                throw new ResponsesApiException(error, 500);
        }
    }

    /// <summary>
    /// Extracts structured error information from the response body.
    /// Falls back to a generic message including the HTTP status code if parsing fails.
    /// Authorization header values are never included in error messages.
    /// </summary>
    private static (string Message, string? Code, string? Param, string? Type) ExtractErrorInfo(Response response)
    {
        try
        {
            var content = response.Content;
            if (content != null && content.ToMemory().Length > 0)
            {
                var body = content.ToString();
                if (!string.IsNullOrEmpty(body))
                {
                    using var doc = JsonDocument.Parse(body);
                    if (doc.RootElement.TryGetProperty("error", out var errorElement))
                    {
                        string? message = null;
                        string? code = null;
                        string? param = null;
                        string? type = null;

                        if (errorElement.TryGetProperty("message", out var msgElement))
                            message = msgElement.GetString();

                        if (errorElement.TryGetProperty("code", out var codeElement))
                            code = codeElement.GetString();

                        if (errorElement.TryGetProperty("param", out var paramElement) && paramElement.ValueKind != JsonValueKind.Null)
                            param = paramElement.GetString();

                        if (errorElement.TryGetProperty("type", out var typeElement))
                            type = typeElement.GetString();

                        if (!string.IsNullOrEmpty(message) || !string.IsNullOrEmpty(code) || !string.IsNullOrEmpty(param) || !string.IsNullOrEmpty(type))
                        {
                            return (message ?? $"Foundry storage request failed with HTTP {response.Status}.", code, param, type);
                        }
                    }
                }
            }
        }
        catch
        {
            // Parsing failed — fall through to generic message
        }

        return ($"Foundry storage request failed with HTTP {response.Status}.", null, null, null);
    }
}
