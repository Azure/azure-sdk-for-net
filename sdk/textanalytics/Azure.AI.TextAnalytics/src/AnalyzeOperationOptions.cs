// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class AnalyzeOperationOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnalyzeOperationOptions"/>
        /// class.
        /// </summary>
        public AnalyzeOperationOptions()
        {
        }

        /// <summary>
        /// The first top documents from the result.
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// The skipped documents from the result. The Skip is called first when used with Top.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// EntitiesTaskParameters.
        /// </summary>
        public EntitiesTaskParameters EntitiesTaskParameters { get; set; }

        /// <summary>
        /// PiiTaskParameters.
        /// </summary>
        public PiiTaskParameters PiiTaskParameters { get; set; }

        /// <summary>
        /// KeyPhrasesTaskParameters.
        /// </summary>
        public KeyPhrasesTaskParameters KeyPhrasesTaskParameters { get; set; }

        /// <summary>
        /// DisplayName property for Analyze job.
        /// </summary>
        public string DisplayName { get; set; }
    }
}
