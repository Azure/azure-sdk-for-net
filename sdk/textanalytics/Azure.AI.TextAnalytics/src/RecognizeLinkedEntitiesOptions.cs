// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run. For example set model version or whether to include statistics.
    /// </summary>
    public class RecognizeLinkedEntitiesOptions : TextAnalyticsRequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecognizeLinkedEntitiesOptions"/>
        /// class which allows callers to specify details about how the operation
        /// is run. For example set model version or whether to include statistics.
        /// </summary>
        public RecognizeLinkedEntitiesOptions()
        {
        }
    }
}
