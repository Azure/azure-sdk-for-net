// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A set of options used to configure dynamic classification.
    /// </summary>
    public class DynamicClassifyOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicClassifyOptions"/> class.
        /// </summary>
        public DynamicClassifyOptions()
        {
        }

        /// <summary>
        /// The type of classification to perform indicating whether the result considers a single category or multiple
        /// categories. If not set, the service default is used.
        /// </summary>
        public ClassificationType? ClassificationType { get; set; }
    }
}
