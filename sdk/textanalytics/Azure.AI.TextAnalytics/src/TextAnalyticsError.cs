// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    internal readonly struct TextAnalyticsError
    {
        internal TextAnalyticsError(TextAnalyticsErrorCode code, string message, string target, TextAnalyticsInnerError innerError, IList<TextAnalyticsError> details)
        {
            Code = code;
            Message = message;
            Target = target;
            InnerError = innerError;
            Details = new ReadOnlyCollection<TextAnalyticsError>(details);
        }

        /// <summary>
        /// </summary>
        public TextAnalyticsErrorCode Code { get; }

        /// <summary>
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// </summary>
        public TextAnalyticsInnerError InnerError { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsError> Details { get; }
    }
}
