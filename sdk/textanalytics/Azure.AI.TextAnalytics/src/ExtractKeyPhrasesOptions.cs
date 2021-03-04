// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run. For example set model version and whether to include statistics.
    /// </summary>
    public class ExtractKeyPhrasesOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractKeyPhrasesOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example set model version, whether to include statistics.
        /// </summary>
        public ExtractKeyPhrasesOptions()
        {
        }
    }
}
