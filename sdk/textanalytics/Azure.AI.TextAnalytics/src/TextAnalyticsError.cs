// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextAnalyticsError
    {
        internal TextAnalyticsError(TextAnalyticsErrorCode code, string message, string target = null, TextAnalyticsError innerError = null, IList<TextAnalyticsError> details = null)
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
        public TextAnalyticsError InnerError { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsError> Details { get; }
    }
}
