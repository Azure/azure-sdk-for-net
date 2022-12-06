// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.TextAnalytics;
using Azure.AI.TextAnalytics.Models;

#nullable enable

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Extend ClientDiagnostics to customize the exceptions thrown by the
    /// generated code.
    /// </summary>
    internal sealed class TextAnalyticsClientDiagnostics : ClientDiagnostics
    {
        public TextAnalyticsClientDiagnostics(ClientOptions options) : base(options)
        {
        }

        /// <summary>
        /// Customize the exception messages we throw from the protocol layer by
        /// attempting to parse them as <see cref="TextAnalyticsError"/>s.
        /// </summary>
        /// <param name="content">The error content.</param>
        /// <param name="responseHeaders">The response headers.</param>
        /// <param name="additionalInfo">Additional error details.</param>
        protected override ResponseError? ExtractFailureContent(
            string? content,
            ResponseHeaders responseHeaders,
            ref IDictionary<string, string>? additionalInfo)
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
                        TextAnalyticsError error = Transforms.ConvertToError(Error.DeserializeError(errorElement));

                        return new ResponseError(error.ErrorCode.ToString(), error.Message);
                    }
                }
                catch (JsonException)
                {
                    // Ignore any failures - unexpected content will be
                    // included verbatim in the detailed error message
                }
            }

            return null;
        }
    }
}
