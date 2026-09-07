// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;

/// <summary>
/// Maps HTTP error responses from the Foundry task storage API to
/// <see cref="TaskStoreException"/> with the matching protocol code/status.
/// </summary>
internal static class TaskStorageErrorMapper
{
    /// <summary>
    /// Exception.Data key that marks an exception as originating from the SDK's
    /// own infrastructure (storage transport, authentication, internal pipeline).
    /// </summary>
    internal const string PlatformErrorDataKey = "Azure.AI.AgentServer.PlatformError";

    /// <summary>
    /// Throws <see cref="TaskStoreException"/> if the response indicates an error condition.
    /// </summary>
    /// <param name="response">The Azure.Core HTTP response to check.</param>
    /// <param name="taskId">The task id, when known, for error context.</param>
    public static void ThrowIfError(Response response, string? taskId)
    {
        if (!response.IsError)
        {
            return;
        }

        var status = response.Status;
        var (code, message) = ExtractErrorInfo(response, status);

        // Map the HTTP status + body code to TaskStoreException codes.
        string resolvedCode = status switch
        {
            400 => code ?? TaskStoreException.CodeInvalidRequest,
            404 => TaskStoreException.CodeTaskNotFound,
            409 => ResolveConflictCode(code),
            412 => ResolvePreConditionCode(code),
            429 => TaskStoreException.CodeRateLimited,
            _ => code ?? TaskStoreException.CodeInternalError,
        };

        int resolvedStatus = status switch
        {
            >= 400 and < 600 => status,
            _ => 500,
        };

        // etag_mismatch is always paired with HTTP 412 to match LocalTaskStore classification,
        // even when the server reported it on a 409 response.
        if (string.Equals(resolvedCode, TaskStoreException.CodeEtagMismatch, StringComparison.Ordinal))
        {
            resolvedStatus = 412;
        }

        throw new TaskStoreException(resolvedCode, resolvedStatus, message ?? $"Task storage request failed with HTTP {status}.", taskId);
    }

    private static string ResolveConflictCode(string? bodyCode)
    {
        if (bodyCode is not null)
        {
            if (string.Equals(bodyCode, TaskStoreException.CodeBindingMismatch, StringComparison.Ordinal))
            {
                return TaskStoreException.CodeBindingMismatch;
            }

            if (string.Equals(bodyCode, TaskStoreException.CodeLeaseHeld, StringComparison.Ordinal))
            {
                return TaskStoreException.CodeLeaseHeld;
            }

            if (string.Equals(bodyCode, TaskStoreException.CodeEtagMismatch, StringComparison.Ordinal))
            {
                return TaskStoreException.CodeEtagMismatch;
            }

            if (string.Equals(bodyCode, TaskStoreException.CodeTaskAlreadyExists, StringComparison.Ordinal))
            {
                return TaskStoreException.CodeTaskAlreadyExists;
            }

            return bodyCode;
        }

        return TaskStoreException.CodeConflict;
    }

    private static string ResolvePreConditionCode(string? bodyCode)
    {
        if (bodyCode is not null &&
            string.Equals(bodyCode, TaskStoreException.CodeEtagMismatch, StringComparison.Ordinal))
        {
            return TaskStoreException.CodeEtagMismatch;
        }

        return bodyCode ?? TaskStoreException.CodeEtagMismatch;
    }

    private static (string? Code, string? Message) ExtractErrorInfo(Response response, int status)
    {
        try
        {
            var content = response.Content;
            if (content is not null && content.ToMemory().Length > 0)
            {
                var body = content.ToString();
                if (!string.IsNullOrEmpty(body))
                {
                    using var doc = JsonDocument.Parse(body);
                    if (doc.RootElement.TryGetProperty("error", out var errorElement))
                    {
                        string? code = null;
                        string? message = null;

                        if (errorElement.TryGetProperty("code", out var codeElement))
                        {
                            code = codeElement.GetString();
                        }

                        if (errorElement.TryGetProperty("message", out var msgElement))
                        {
                            message = msgElement.GetString();
                        }

                        return (code, message);
                    }
                }
            }
        }
        catch
        {
            // Parsing failed — fall through to null
        }

        return (null, null);
    }
}
