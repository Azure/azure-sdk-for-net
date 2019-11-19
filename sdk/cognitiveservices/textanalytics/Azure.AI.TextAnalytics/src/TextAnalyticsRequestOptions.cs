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
        /// <param name="showStatistics"></param>
        /// <param name="modelVersion"></param>
        public TextAnalyticsRequestOptions(bool showStatistics = false, string modelVersion = default)
        {
            ShowStatistics = showStatistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// </summary>
        public bool ShowStatistics { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }
    }
}
