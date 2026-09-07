// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.AI.AgentServer.Core.Storage
{
    /// <summary>
    /// Inspects a storage <see cref="Response"/> and throws the mapped
    /// <see cref="FoundryStorageException"/> subtype when the status code indicates failure.
    /// </summary>
    internal static class StorageErrors
    {
        /// <summary>Throws the appropriate exception if <paramref name="response"/> represents an error.</summary>
        /// <param name="response">The HTTP response to inspect.</param>
        internal static void ThrowIfError(Response response)
        {
            int status = response.Status;
            if (status >= 200 && status < 300)
            {
                return;
            }

            (string message, string? param, string? code) = ExtractError(response);

            switch (status)
            {
                case 404:
                    throw new FoundryStorageNotFoundException(message, code);
                case 409:
                    throw new FoundryStorageConflictException(message, param, code);
                case 400:
                    throw new FoundryStorageBadRequestException(message, param, 400, code);
                case 412:
                    string? currentETag = response.Headers.TryGetValue("ETag", out string? etag) ? etag : null;
                    throw new FoundryStoragePreconditionException(message, currentETag, code);
                default:
                    throw new FoundryStorageApiException(status, message, code);
            }
        }

        private static (string Message, string? Param, string? Code) ExtractError(Response response)
        {
            string fallback = $"Storage request failed with status {response.Status}.";
            try
            {
                BinaryData content = response.Content;
                if (content is null || content.ToMemory().IsEmpty)
                {
                    return (fallback, null, null);
                }

                using JsonDocument doc = JsonDocument.Parse(content);
                JsonElement root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.Object && root.TryGetProperty("error", out JsonElement error)
                    && error.ValueKind == JsonValueKind.Object)
                {
                    string message = error.TryGetProperty("message", out JsonElement m) && m.ValueKind == JsonValueKind.String
                        ? m.GetString()!
                        : fallback;
                    string? param = error.TryGetProperty("param", out JsonElement p) && p.ValueKind == JsonValueKind.String
                        ? p.GetString()
                        : null;
                    string? code = error.TryGetProperty("code", out JsonElement c) && c.ValueKind == JsonValueKind.String
                        ? c.GetString()
                        : null;
                    return (message, param, code);
                }

                return (fallback, null, null);
            }
            catch (JsonException)
            {
                return (fallback, null, null);
            }
        }
    }
}
