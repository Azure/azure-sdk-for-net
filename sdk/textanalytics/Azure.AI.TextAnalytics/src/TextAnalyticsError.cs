// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Text Analitics Error.
    /// </summary>
    public struct TextAnalyticsError
    {
        internal TextAnalyticsError(string errorCode, string message, string target = null)
        {
            ErrorCode = errorCode;
            Message = message;
            Target = target;
        }

        /// <summary>
        /// Error code that serves as an indicator of the HTTP error code.
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// Message that contains more information about the reason of the error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Target of the particular error (e.g. the name of
        /// the property in error).
        /// </summary>
        public string Target { get; }
    }
}
