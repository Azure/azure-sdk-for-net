﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.FormRecognizer.Models;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Extend ClientDiagnostics to customize the exceptions thrown by the
    /// generated code.
    /// </summary>
    internal sealed partial class ClientDiagnostics
    {
        /// <summary>
        /// Customize the exception messages we throw from the protocol layer by
        /// attempting to parse them as <see cref="FormRecognizerError"/>s.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="message">The error message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="additionalInfo">Additional error details.</param>
#pragma warning disable CA1822 // Member can be static
#pragma warning disable CA1801 // Remove unused parameter
        partial void ExtractFailureContent(
            string? content,
            ResponseHeaders responseHeaders,
            ref string? message,
            ref string? errorCode,
            ref IDictionary<string, string>? additionalInfo)
#pragma warning restore CA1801 // Remove unused parameter
#pragma warning restore CA1822 // Member can be static
        {
            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    // Try to parse the failure content and use that as the
                    // default value for the message, error code, etc.
                    using JsonDocument doc = JsonDocument.Parse(content);
                    if (doc.RootElement.TryGetProperty("error", out JsonElement errorElement))
                    {
                        FormRecognizerError error = FormRecognizerError.DeserializeFormRecognizerError(errorElement);
                        message ??= error?.Message;
                        errorCode ??= error?.ErrorCode;
                    }
                }
                catch (JsonException)
                {
                    // Ignore any failures - unexpected content will be
                    // included verbatim in the detailed error message
                }
            }
        }
    }
}
