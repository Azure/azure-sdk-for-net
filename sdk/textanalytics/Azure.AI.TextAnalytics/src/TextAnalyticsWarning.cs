// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analytics Warning.
    /// </summary>
    public struct TextAnalyticsWarning
    {
        internal TextAnalyticsWarning(string code, string message)
        {
            WarningCode = code;
            Message = message;
        }

        /// <summary>
        /// Code indicating the type of warning.
        /// </summary>
        public string WarningCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the warning.
        /// </summary>
        public string Message { get; }
    }
}
