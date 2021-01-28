// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// </summary>
    public class HealthcareOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthcareOptions"/>
        /// class.
        /// </summary>
        public HealthcareOptions()
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
    }
}
