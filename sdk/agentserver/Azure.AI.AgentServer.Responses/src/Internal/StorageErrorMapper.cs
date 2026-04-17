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
        var message = ExtractMessage(response);

        switch (status)
        {
            case 404:
                throw new ResourceNotFoundException(message);
            case 400:
            case 409:
                throw new BadRequestException(message);
            default:
                throw new ResponsesApiException(new Error("storage_error", message), status);
        }
    }

    /// <summary>
    /// Extracts an error message from the response body.
    /// Falls back to a generic message including the HTTP status code if parsing fails.
    /// Authorization header values are never included in error messages.
    /// </summary>
    private static string ExtractMessage(Response response)
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
                        if (errorElement.TryGetProperty("message", out var msgElement))
                        {
                            var msg = msgElement.GetString();
                            if (!string.IsNullOrEmpty(msg))
                                return msg;
                        }
                    }
                }
            }
        }
        catch
        {
            // Parsing failed — fall through to generic message
        }

        return $"Foundry storage request failed with HTTP {response.Status}.";
    }
}
