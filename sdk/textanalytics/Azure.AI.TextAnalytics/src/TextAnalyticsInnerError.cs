// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    // TODO: Workaround for this?
    // Must be class because of Error CS0523: Struct member 'TextAnalyticsInnerError.InnerError' of type 'TextAnalyticsInnerError' causes a cycle in the struct layout
    public class TextAnalyticsInnerError
    {
        internal TextAnalyticsInnerError(TextAnalyticsInnerErrorCode code, string message, string target, TextAnalyticsInnerError innerError)
        {
            Code = code;
            Message = message;
            Target = target;
            InnerError = innerError;
        }

        /// <summary>
        /// </summary>
        public TextAnalyticsInnerErrorCode Code { get; }

        /// <summary>
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// </summary>
        public TextAnalyticsInnerError InnerError { get; }
    }
}
