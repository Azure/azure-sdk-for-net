// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics Error.
    /// </summary>
    [CodeGenModel("TextAnalyticsError")]
    public partial struct TextAnalyticsError
    {
        internal TextAnalyticsError(string code, string message, string target = null)
            : this()
        {
            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            ErrorCode = code;
            Message = message;
            Target = target;
        }

        internal TextAnalyticsError(ErrorCodeValue code, string message, string target, InnerError innererror, IEnumerable<TextAnalyticsError> details)
        {
            Code = code;
            ErrorCode = code.ToString();
            Message = message;
            Target = target;
            Innererror = innererror;
            Details = details.ToList();
        }

        internal TextAnalyticsError(ErrorCodeValue code, string message, string target, InnerError innererror, IReadOnlyList<TextAnalyticsError> details)
        {
            Code = code;
            ErrorCode = code.ToString();
            Message = message;
            Target = target;
            Innererror = innererror;
            Details = details;
        }

        /// <summary>
        /// Error code that serves as an indicator of the HTTP error code.
        /// </summary>
        public TextAnalyticsErrorCode ErrorCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Target of the particular error (e.g. the name of
        /// the property in error).
        /// </summary>
        public string Target { get; }

        /// <summary> Generated Error code. </summary>
        internal ErrorCodeValue Code { get; }
        /// <summary> Generated inner error contains more specific information. </summary>
        internal InnerError Innererror { get; }
        /// <summary> Generated details about specific errors that led to this reported error. </summary>
        internal IReadOnlyList<TextAnalyticsError> Details { get; }

        internal static TextAnalyticsError DeserializeTextAnalyticsError(JsonElement element)
        {
            string errorCode = default;
            string message = default;
            string target = default;
            TextAnalyticsError innerError = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    errorCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    innerError = DeserializeTextAnalyticsError(property.Value);
                    continue;
                }
            }

            // Return the innermost error, which should be only one level down.
            return innerError.ErrorCode == default ? new TextAnalyticsError(errorCode, message, target) : innerError;
        }
    }
}
