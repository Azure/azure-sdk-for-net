﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsRequestOptions"/>
        /// class.
        /// </summary>
        public TextAnalyticsRequestOptions()
        {
        }

        /// <summary>
        /// Gets or sets a value that, if set to true, indicates that the service
        /// should return document and document batch statistics with the results
        /// of the operation.
        /// </summary>
        public bool IncludeStatistics { get; set; }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/how-tos/text-analytics-how-to-sentiment-analysis#model-versioning"/>.
        /// </summary>
        public string ModelVersion { get; set; }
    }
}
