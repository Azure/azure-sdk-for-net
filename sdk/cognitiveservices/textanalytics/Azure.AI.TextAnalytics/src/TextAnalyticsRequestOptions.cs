// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class TextAnalyticsRequestOptions
    {
        /// <summary>
        /// </summary>
        /// <param name="includeStatistics"></param>
        /// <param name="modelVersion"></param>
        public TextAnalyticsRequestOptions(bool includeStatistics = false, string modelVersion = default)
        {
            IncludeStatistics = includeStatistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// </summary>
        public bool IncludeStatistics { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }
    }
}
