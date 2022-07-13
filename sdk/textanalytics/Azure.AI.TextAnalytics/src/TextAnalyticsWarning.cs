// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics Warning.
    /// </summary>
    public readonly struct TextAnalyticsWarning
    {
        internal TextAnalyticsWarning(TextAnalyticsWarningInternal warning)
            : this(warning.Code, warning.Message)
        {
        }

        internal TextAnalyticsWarning(DocumentWarning warning)
            : this(warning.Code.ToString(), warning.Message)
        {
        }

        internal TextAnalyticsWarning(string warningCode, string message)
        {
            WarningCode = warningCode;
            Message = message;
        }

        /// <summary>
        /// Code indicating the type of warning.
        /// </summary>
        public TextAnalyticsWarningCode WarningCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the warning.
        /// </summary>
        public string Message { get; }
    }
}
