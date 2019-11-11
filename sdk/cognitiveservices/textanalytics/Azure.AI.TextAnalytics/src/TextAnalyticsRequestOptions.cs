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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        public TextAnalyticsRequestOptions(bool showStats = false, string modelVersion = default)
        {
            ShowStats = showStats;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// </summary>
        public bool ShowStats { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }
    }
}
