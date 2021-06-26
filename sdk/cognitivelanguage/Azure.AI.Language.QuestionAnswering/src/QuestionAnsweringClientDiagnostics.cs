// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.Language.QuestionAnswering.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.QuestionAnswering
{
    /// <summary>
    /// <see cref="ClientDiagnostics"/> for the Question Answering SDK.
    /// </summary>
    internal class QuestionAnsweringClientDiagnostics : ClientDiagnostics
    {
        /// <summary>
        /// Creates a new instance of the <see cref="QuestionAnsweringClientDiagnostics"/> class.
        /// </summary>
        /// <param name="options"><see cref="ClientOptions"/> to initialize diagnostics.</param>
        public QuestionAnsweringClientDiagnostics(ClientOptions options) : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void ExtractFailureContent(
            string content,
            ResponseHeaders responseHeaders,
            ref string message,
            ref string errorCode,
            ref IDictionary<string, string> additionalInfo)
        {
            if (!string.IsNullOrEmpty(content))
            {
                try
                {
                    using JsonDocument doc = JsonDocument.Parse(content);
                    ErrorResponse response = ErrorResponse.DeserializeErrorResponse(doc.RootElement);

                    if (response.Error.Details?.Count > 0)
                    {
                        Error details = response.Error.Details[0];

                        errorCode = details.Code.ToString();
                        message = details.Message;

                        additionalInfo ??= new Dictionary<string, string>(1, StringComparer.OrdinalIgnoreCase);
                        additionalInfo[nameof(Error.Target)] = details.Target;
                    }
                    else
                    {
                        errorCode = response.Error.Code.ToString();
                        message = response.Error.Message;
                    }
                }
                catch (JsonException)
                {
                    // Ignore JSON deserialization failures.
                    // Unexpected content will be included in the detailed error message.
                }
            }
        }
    }
}
