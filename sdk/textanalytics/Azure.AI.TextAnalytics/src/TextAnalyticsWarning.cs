// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics Warning.
    /// </summary>
    public struct TextAnalyticsWarning
    {
        internal TextAnalyticsWarning(TextAnalyticsWarningInternal warning)
        {
            WarningCode = warning.Code;
            Message = warning.Message;
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
