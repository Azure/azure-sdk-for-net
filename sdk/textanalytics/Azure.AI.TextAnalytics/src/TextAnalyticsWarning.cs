// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics Warning.
    /// </summary>
    [CodeGenModel("TextAnalyticsWarning")]
    public partial struct TextAnalyticsWarning
    {
        internal TextAnalyticsWarning(string code, string message)
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

            WarningCode = code;
            Message = message;

            //fill auto-generated properties
            Code = code;
            TargetRef = default;
        }

        /// <summary>
        /// Auto-generated constructor with properties we don't need.
        /// </summary>
        internal TextAnalyticsWarning(WarningCodeValue code, string message, string targetRef)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (targetRef == null)
            {
                throw new ArgumentNullException(nameof(targetRef));
            }

            Code = code;
            WarningCode = code.ToString();
            Message = message;
            TargetRef = targetRef;
        }

        /// <summary>
        /// Code indicating the type of warning.
        /// </summary>
        public TextAnalyticsWarningCode WarningCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the warning.
        /// </summary>
        public string Message { get; }

        /// <summary> Generated error code. </summary>
        internal WarningCodeValue Code { get; }
        internal string TargetRef { get; }

        internal static TextAnalyticsWarning DeserializeTextAnalyticsWarning(JsonElement element)
        {
            string code = default;
            string message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new TextAnalyticsWarning(code, message);
        }
    }
}
