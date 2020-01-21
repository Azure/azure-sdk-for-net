// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public readonly struct TextAnalyticsError
    {
        internal TextAnalyticsError(string errorCode, string message, string target = null)
        {
            ErrorCode = errorCode;
            Message = message;
            Target = target;
        }

        /// <summary>
        /// </summary>
        public string ErrorCode { get; }

        /// <summary>
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// </summary>
        public string Target { get; }
    }
}
