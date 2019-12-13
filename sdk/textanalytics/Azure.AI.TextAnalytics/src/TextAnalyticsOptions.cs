// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextAnalyticsOptions
    {
        /// <summary>
        /// </summary>
        public TextAnalyticsOptions()
        {
        }

        /// <summary>
        /// </summary>
        public bool IncludeStatistics { get; set; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; set; }
    }
}
