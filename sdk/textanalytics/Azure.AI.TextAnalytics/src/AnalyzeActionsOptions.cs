// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Options that allow callers to specify details about how the operation
    /// is run and what information is returned from it by the service.
    /// <para>For example, whether to include statistics.</para>
    /// </summary>
    public class AnalyzeActionsOptions
    {
        /// <summary>
        /// Gets or sets a value that, if set to true, indicates that the service
        /// should return statistics with the results of the operation.
        /// </summary>
        public bool? IncludeStatistics { get; set; }
    }
}
