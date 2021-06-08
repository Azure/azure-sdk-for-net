﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// <para>For example, set model version, whether to include statistics,
    /// and more.</para>
    /// </summary>
    public class TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsRequestOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example, set model version, whether to include statistics, and more.
        /// </summary>
        public TextAnalyticsRequestOptions()
        {
        }

        internal TextAnalyticsRequestOptions(bool includeStatistics, string modelVersion)
        {
            IncludeStatistics = includeStatistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// Gets or sets a value that, if set to true, indicates that the service
        /// should return document and document batch statistics with the results
        /// of the operation.
        /// Returns data for batch document methods only.
        /// </summary>
        public bool IncludeStatistics { get; set; }

        /// <summary>
        /// Gets or sets a value that, if set, indicates the version of the text
        /// analytics model that will be used to generate the result.  For supported
        /// model versions, see operation-specific documentation, for example:
        /// <see href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-how-to-sentiment-analysis#model-versioning"/>.
        /// </summary>
        public string ModelVersion { get; set; }

        /// <summary>
        /// The default value of this property is 'false', except for methods like 'StartAnalyzeHealthcareEntities' and 'RecognizePiiEntities'.
        /// This means, Text Analytics service logs your input text for 48 hours, solely to allow for troubleshooting issues.
        /// Setting this property to true, disables input logging and may limit our ability to investigate issues that occur.
        /// </summary>
        /// <remarks>
        /// This property only applies for <see cref="TextAnalyticsClientOptions.ServiceVersion.V3_1_Preview_5"/> and up.
        /// </remarks>
        public bool? DisableServiceLogs { get; set; }
    }
}
